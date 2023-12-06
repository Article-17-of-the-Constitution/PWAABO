using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Debug.Log("게임시작");
    }
    public void OnClickCharacterChoice() 
    {
        Debug.Log("캐릭터 선택");
    }
    public void OnClickLevelChoiceScene() 
    {
        Debug.Log("난이도 선택");
    }
    public void OnClickOption() 
    {
        Debug.Log("옵션");
    }

    public void OnClickQuit() 
    {
        Debug.Log("");

    }
}


