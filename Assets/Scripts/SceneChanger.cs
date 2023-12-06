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

    public void OnClickGameStart() 
    {
        SceneManager.LoadScene("CCS");
    }

    public void ChoiceNaluhodo() 
    {
        SelectedPlayer = Player.Naruhodo;
        Debug.Log("캐릭터가 나루호도로 설정되었습니다.");
        SceneManager.LoadScene("DCS");
    }
    public void ChoiceMitsurugi()
    {
        SelectedPlayer = Player.Mitsurugi;
        Debug.Log("캐릭터가 미츠루기로 설정되었습니다.");
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

}


