using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public DifficultyManager.DifficultyLevel currentDifficulty;
    private float defaultTimeLimit = 60f;

    private float startTime;
    private float elapsedTime;

    private float easyDropRate = 0.1f;
    private float hardDropRate = 0.05f;

    public Sprite itemSprite;

    [Header("Ball")]
    public Ball ball;


    [Header("UI")]
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

    void Start()
    {
        startTime = Time.time;
        currentDifficulty = DifficultyManager.SelectedDifficulty;
        SetTimeLimit();
    }
    void Update()
    {
        elapsedTime = Time.time - startTime;

        if (elapsedTime >= defaultTimeLimit)
        {
            EndGame();
        }
    }
    void SetTimeLimit()
    {
        switch (currentDifficulty)
        {
            case DifficultyManager.DifficultyLevel.Easy:
                defaultTimeLimit = 60f;
                break;
            case DifficultyManager.DifficultyLevel.Hard:
                defaultTimeLimit = 30f;
                break;
        }
        Debug.Log("제한 시간이 " + defaultTimeLimit + "초로 설정되었습니다.");
    }
    void EndGame()
    {
        Debug.Log("게임 종료! 경과 시간: " + elapsedTime + "초");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            float dropRate = (currentDifficulty == DifficultyManager.DifficultyLevel.Easy) ? easyDropRate : hardDropRate;

            if (Random.value <= dropRate)
            {
                SpawnItem();
            }
            Destroy(gameObject);
        }
    }
    void SpawnItem()
    {
        Vector3 spawnPosition = transform.position;

        GameObject item = new GameObject("Item");
        item.transform.position = spawnPosition;

        SpriteRenderer spriteRenderer = item.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemSprite;

        Debug.Log("아이템이 생성되었습니다!");
    }


}
