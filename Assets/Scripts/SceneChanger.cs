using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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

    public void OnClickCharacterChoice() 
    {
        SceneManager.LoadScene("DCS");
    }

    public void OnClickLevelChoiceScene() 
    {
        SceneManager.LoadScene("Stage1Scene");
    }

    public void OnClickRetry() 
    {
        SceneManager.LoadScene("Stage1Scene");
    }

    public void OnClickGoStart() 
    {
        SceneManager.LoadScene("StartScene");
    }

}


