using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Shop_Creation 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
