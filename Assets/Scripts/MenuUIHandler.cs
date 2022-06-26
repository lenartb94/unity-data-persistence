using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField nameField;
    [SerializeField]
    private TMP_Text bestScoreText;

    void Start()
    {
        bestScoreText.text = "Best Score: " + DataManager.BestScore;
    }

    public void OnStartClicked()
    {
        if (nameField.text.Trim().Length > 0)
        {
            DataManager.Name = nameField.text.Trim();
            SceneManager.LoadScene(1);
        }
    }

    public void OnQuitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
