using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

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
