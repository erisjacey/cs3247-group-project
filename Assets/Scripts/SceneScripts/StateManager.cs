using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StateManager : MonoBehaviour
{
    public void Retry()
    {   
        // index 1 represents start of supermarket
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void BackToMainMenu()
    {   
        // index 0 represents the main menu
        SceneManager.LoadScene(0);
    }
}
