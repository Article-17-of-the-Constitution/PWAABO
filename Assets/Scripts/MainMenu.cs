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

        Debug.Log("���ӽ���");
    }
    public void OnClickCharacterChoice() 
    {
        SceneManager.LoadScene("CCS");
    }
    public void OnClickLevelChoiceScene() 
    {
        Debug.Log("���̵� ����");
    }
    public void OnClickOption() 
    {
        Debug.Log("�ɼ�");
    }

    public void OnClickQuit() 
    {
        Debug.Log("");

    }
}


