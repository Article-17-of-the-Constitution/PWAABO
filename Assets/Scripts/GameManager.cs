using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public DifficultyManager.DifficultyLevel currentDifficulty;
    private float defaultTimeLimit = 60f;

    private float startTime;
    private float elapsedTime;
    public Text timeTxt;
    public GameObject GameOverPanel;
    public GameObject WinPanel;
    public GameObject brick;
    public AudioSource audioSource;
    public AudioClip BGMend;
    public AudioClip BGMclear;
    float time;
    public static GameManager I;
    private float easyDropRate = 0.1f;
    private float hardDropRate = 0.05f;

    public Sprite itemSprite;

    [Header("Ball")]
    public Ball ball;


    [Header("UI")]
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    void Awake()
    {
        I = this;
    }
    void Start()
    {
        
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Stage1Scene")
        {
            initGame();

            for (int i = 0; i < 64; i++)
            {

                GameObject newBricks = Instantiate(brick);
                newBricks.transform.parent = GameObject.Find("Brick").transform;

                float x = (i / 8) * 2.06f - 7.2f;
                float y = (i % 8) * 0.3f + 2.1f;
                newBricks.transform.position = new Vector3(x, y, 0);

            }
        }
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
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time <= 0)
        {
            GameEnd();
        }
        else
        {
            int bricksLeft = GameObject.Find("Brick").transform.childCount;
            if (bricksLeft == 0)
            {
                GameClear();

            }
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
        Debug.Log("���� �ð��� " + defaultTimeLimit + "�ʷ� �����Ǿ����ϴ�.");
    }
    void EndGame()
    {
        Debug.Log("���� ����! ��� �ð�: " + elapsedTime + "��");
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

        Debug.Log("�������� �����Ǿ����ϴ�!");
    }
    public void GameEnd()
    {
        Time.timeScale = 0.00f;
        audioSource.clip = BGMend;
        audioSource.Play();

        GameOverPanel.SetActive(true);

    }

    public void GameClear()
    {
        Time.timeScale = 0.00f;
        audioSource.clip = BGMclear;
        audioSource.Play();
        WinPanel.SetActive(true);
    }
    void initGame()
    {
        Time.timeScale = 1.0f;
        time = 60.0f;

    }


}
