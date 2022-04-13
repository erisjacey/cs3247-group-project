using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button resumeGameButton;
    private TextMeshProUGUI resumeGameText;

    void Start() 
    {
        resumeGameText = resumeGameButton.GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        resumeGameButton.interactable = LevelManager.hasSavedGame;
        if (!LevelManager.hasSavedGame) 
        {
            resumeGameText.color = new Color(0.6f, 0.6f, 0.6f, 0.6f);
        }
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("Prologue_Cutscene");
        FindObjectOfType<LevelManager>().ResetGame();
    }

    public void ResumeGame()
    {
        FindObjectOfType<LevelManager>().ResumeGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
