using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    private const int ANXIETY = 0;
    private const int FEAR = 1;
    private const int ANGER = 2;

    private bool isTutorial = true;
    private int currentLevel = ANXIETY;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.LogError(currentScene);

        if (currentScene.Contains("Supermarket")) currentLevel = ANXIETY;
        if (currentScene.Contains("Classroom")) currentLevel = FEAR;
        if (currentScene.Contains("House")) currentLevel = ANGER;

        Debug.LogError(currentLevel);

    }
    public void LoadCheckpoint() 
    {
        Debug.LogError(currentLevel);
        switch (currentLevel)
        {
            case ANXIETY:
                SceneManager.LoadScene("Shop_Creation 1");
                break;
            case FEAR:
                SceneManager.LoadScene("Shop_Creation 2");
                break;
            case ANGER:
                SceneManager.LoadScene("Shop_Creation 3");
                break;
            default:
                break;
        }
    }

    public void LoadNextLevel() 
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (isTutorial) 
        {
            isTutorial = false;
            SceneManager.LoadScene("Opening_Cutscene");
        }
        else if (currentScene == "Shop_Creation 1")
        {
            currentLevel = ANXIETY;
            SceneManager.LoadScene("Supermarket 1");
        } 
        else if (currentScene == "Shop_Creation 2")
        {
            currentLevel = FEAR;
            SceneManager.LoadScene("Classroom");
        }
        else if (currentScene == "Shop_Creation 3")
        {
            currentLevel = ANGER;
            SceneManager.LoadScene("House 1");
        }

        FindObjectOfType<PlayerLocationManager>().SetLocation("");
    }
}
