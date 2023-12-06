using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    public enum DifficultyLevel
    {
        Easy,Hard
    }
    public static DifficultyLevel SelectedDifficulty;

    public Button easyButton;
    public Button hardButton;

    void Start()
    {
        easyButton.onClick.AddListener(OnEasyButtonClick);
        hardButton.onClick.AddListener(OnHardButtonClick);
    }
    void OnEasyButtonClick()
    {
        SelectedDifficulty = DifficultyLevel.Easy;
        Debug.Log("���̵��� Easy�� �����Ǿ����ϴ�.");
        SceneManager.LoadScene("Stage1Scene");
    }
    void OnHardButtonClick()
    {
        SelectedDifficulty = DifficultyLevel.Hard;
        Debug.Log("���̵��� Hard�� �����Ǿ����ϴ�.");
        SceneManager.LoadScene("Stage1Scene");
    }
}
