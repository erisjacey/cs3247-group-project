using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public void Retry()
    {   
        // index 1 represents start of supermarket
        FindObjectOfType<CheckpointManager>().LoadCheckpoint();
        FindObjectOfType<LevelManager>().ResetGame();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {   
        // index 0 represents the main menu
        SceneManager.LoadScene(0);

        FindObjectOfType<LevelManager>().SaveGame();

        // FindObjectOfType<LevelManager>().ResetGame();
    }

    public void LoadNextLevel() 
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Supermarket 3")
        {
            SceneManager.LoadScene("Anxiety_Cutscene");
        } 
        else if (currentScene == "Classroom 2")
        {
            SceneManager.LoadScene("Fear_Cutscene");
        }
        else if (currentScene == "House 3")
        {
            SceneManager.LoadScene("Anger_Cutscene");
        }
    }
}
