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
    private float TimeLimit = 90f;
    public Text timeTxt;
    public GameObject brick;
    public static GameManager I;
    public float DropRate = 1f;
    public GameObject Item;
    private int BrickCount = 0;
    private float BrickXInterval = 0;
    private float BrickYInterval = 0;
    public GameObject Naruhodo;
    public GameObject Mitsurugi;
    public Text LifeTxt;
    public int Life = 0;

    void Awake()
    {
        I = this;
    }
    void Start()
    {

        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Stage1Scene")
        {
            InitGame();
        }

    }
    void Update()
    {
        TimeLimit -= Time.deltaTime;
        timeTxt.text = TimeLimit.ToString("N2");
        LifeTxt.text = Life.ToString("N0");

        if (TimeLimit <= 0)
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
    void SetDifficulty()
    {
        switch (DifficultyManager.SelectedDifficulty)
        {
            case DifficultyManager.DifficultyLevel.Easy:
                TimeLimit *= 1f;
                DropRate *= 0.2f;
                BrickCount = 32;
                BrickXInterval = 3.5f;
                BrickYInterval = 0.4f;
                Life = 3;
                break;
            case DifficultyManager.DifficultyLevel.Hard:
                TimeLimit *= 0.5f;
                DropRate *= 0.1f;
                BrickCount = 64;
                BrickXInterval = 1.4f;
                BrickYInterval = 0.3f;
                Life = 1;
                break;
        }
        Debug.Log("제한 시간이 " + TimeLimit + "초로 설정되었습니다.");
        Debug.Log("드랍율이 " + DropRate + "로 설정되었습니다.");
    }
    void SetPlayer()
    {
        switch (SceneChanger.SelectedPlayer)
        {
            case SceneChanger.Player.Naruhodo:
                GameObject newPlayer1 = Instantiate(Naruhodo);
                newPlayer1.transform.parent = GameObject.Find("Paddle").transform;
                break;
            case SceneChanger.Player.Mitsurugi:
                GameObject newPlayer2 = Instantiate(Mitsurugi);
                newPlayer2.transform.parent = GameObject.Find("Paddle").transform;
                break;
        }
    }
    void SetBricks()
    {
        for (int i = 0; i < BrickCount; i++)
        {

            GameObject newBricks = Instantiate(brick);
            newBricks.transform.parent = GameObject.Find("Brick").transform;

            float x = (i / 8) * BrickXInterval - 5f;
            float y = (i % 8) * BrickYInterval;
            newBricks.transform.position = new Vector3(x, y, 0);

        }
    }

    public void GameEnd()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void GameClear()
    {
        SceneManager.LoadScene("VictoryScene");
    }
    void InitGame()
    {
        Time.timeScale = 1.0f;
        SetDifficulty();
        SetPlayer();
        SetBricks();
    }
    public void LoseLife()
    {
        if (Life > 0)
        {
            Life--;
        }
        else
        {
            GameEnd();
        }
    }


}
