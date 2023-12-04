using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        Debug.Log("���̵��� Easy�� �����Ǿ����ϴ�.");
    }
    void OnHardButtonClick()
    {
        SelectedDifficulty = DifficultyLevel.Hard;
        Debug.Log("���̵��� Hard�� �����Ǿ����ϴ�.");
    }
}
