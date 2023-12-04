using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Text timeTxt;
    public GameObject endTxt;
    public GameObject clearTxt;
    public GameObject brick;       
    float time = 60f;

    public static GameManager I;

    void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        initGame();
        for (int i = 0; i < 32; i++)
        {
            
            GameObject newBricks = Instantiate(brick);
            newBricks.transform.parent = GameObject.Find("Bricks").transform;

            float x = (i / 8) * 1.4f-2.1f;
            float y = (i % 8) * 0.2f+2f ;
            newBricks.transform.position = new Vector3(x, y, 0);

        }       
        
    }
    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time < 0)
        {
            GameEnd();
        }
        else
        {
            int bricksLeft = GameObject.Find("Bricks").transform.childCount;
            if (bricksLeft == 0)
            {
                GameClear();

            }
        }

    }
    




    public void GameEnd()
    {
        Time.timeScale = 0.00f;
        
        endTxt.SetActive(true);

    }

    void GameClear()
    {
        Time.timeScale = 0.00f;
        
        clearTxt.SetActive(true);
    }
    void initGame()
    {
        Time.timeScale = 1.0f;
        
        time = 60.0f;
    }
}
