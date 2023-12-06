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
    public static DifficultyLevel SelectedDifficulty = DifficultyLevel.Easy;

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
        Debug.Log("난이도가 Easy로 설정되었습니다.");
        SceneManager.LoadScene("Stage1Scene");
    }
    void OnHardButtonClick()
    {
        SelectedDifficulty = DifficultyLevel.Hard;
        Debug.Log("난이도가 Hard로 설정되었습니다.");
        SceneManager.LoadScene("Stage1Scene");
    }
}
