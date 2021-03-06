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
        UpdateCurrentLevel();
    }

    public void Start()
    {
        UpdateCurrentLevel();
    }

    void UpdateCurrentLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene.Contains("Supermarket")) currentLevel = ANXIETY;
        if (currentScene.Contains("Classroom")) currentLevel = FEAR;
        if (currentScene.Contains("House")) currentLevel = ANGER;
    }

    public void LoadCheckpoint() 
    {
        Debug.LogError(currentLevel);
        switch (currentLevel)
        {
            case ANXIETY:
                SceneManager.LoadScene("Shop_Creation 1");
                FindObjectOfType<HealthManager>().ResetHealth();
                break;
            case FEAR:
                SceneManager.LoadScene("Shop_Creation 2");
                FindObjectOfType<HealthManager>().ResetHealth();
                break;
            case ANGER:
                SceneManager.LoadScene("Shop_Creation 3");
                FindObjectOfType<HealthManager>().ResetHealth();
                break;
            default:
                break;
        }
    }

    public void LoadNextLevel() 
    {
        string currentScene = SceneManager.GetActiveScene().name;
        
        if (currentScene == "Shop_Creation 1")
        {
            if (isTutorial) 
            {
                isTutorial = false;
                SceneManager.LoadScene("Opening_Cutscene");
                FindObjectOfType<PlayerLocationManager>().SetLocation("");
                return;
            }
            currentLevel = ANXIETY;
            SceneManager.LoadScene("Supermarket 1");
        } 
        else if (currentScene == "Shop_Creation 2")
        {
            currentLevel = FEAR;
            SceneManager.LoadScene("Classroom 1");
        }
        else if (currentScene == "Shop_Creation 3")
        {
            currentLevel = ANGER;
            SceneManager.LoadScene("House 1");
        }

        FindObjectOfType<PlayerLocationManager>().SetLocation("");
    }
}
