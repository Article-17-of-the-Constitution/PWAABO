using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public void OnCharacterButtonClick()
    {
        SceneManager.LoadScene("DifficultyScene");
    }

    public void OnCharacterButton1Click()
    {
        SceneManager.LoadScene("DifficultyScene");
    }
}
