using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void OnEasyButtonClick()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void OnHardButtonClick()
    {
        SceneManager.LoadScene("StageScene");
    }
}
