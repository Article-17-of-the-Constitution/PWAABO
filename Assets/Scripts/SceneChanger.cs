using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DifficultyManager;

public class SceneChanger : MonoBehaviour
{
    public enum Player
    {
        Naruhodo, Mitsurugi
    }
    public static Player SelectedPlayer;
    public GameObject Naruhodo;
    public GameObject Mitsurugi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoCCS() 
    {
        SceneManager.LoadScene("CCS");
    }

    public void ChoiceNaruhodo() 
    {
        SelectedPlayer = Player.Naruhodo;
        Debug.Log("ĳ���Ͱ� ����ȣ���� �����Ǿ����ϴ�.");
        SceneManager.LoadScene("DCS");
    }
    public void ChoiceMitsurugi()
    {
        SelectedPlayer = Player.Mitsurugi;
        Debug.Log("ĳ���Ͱ� �������� �����Ǿ����ϴ�.");
        SceneManager.LoadScene("DCS");
    }

    public void GoRetry() 
    {
        SceneManager.LoadScene("Stage1Scene");
    }

    public void GoStart() 
    {
        SceneManager.LoadScene("StartScene");
    }
    public void GoDCS()
    {
        SceneManager.LoadScene("DCS");
    }

}


