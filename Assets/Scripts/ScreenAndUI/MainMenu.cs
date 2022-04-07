using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void PlayLevelOne()
    {
        SceneManager.LoadScene("Prologue_Cutscene");
    }

    public void PlayLevelTwo()
    {
        SceneManager.LoadScene("Anxiety_Cutscene");
    }

    public void PlayLevelThree()
    {
        SceneManager.LoadScene("Fear_Cutscene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
