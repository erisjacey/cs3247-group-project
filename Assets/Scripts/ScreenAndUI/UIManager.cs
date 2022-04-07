using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Color darkTint = new Color(0f, 0f, 0f, 0.36f);
    [SerializeField] Color redTint = new Color(0.39f, 0.035f, 0f, 0.3f);

    [SerializeField] GameObject levelCanvas;
    [SerializeField] GameObject deathPanel;

    public static bool GameIsPaused = false;

    [SerializeField] GameObject exitMenu;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Menu"
            || currentScene == "Prologue"
            || currentScene.Contains("Cutscene")) 
        {
            levelCanvas.SetActive(false);
            return;
        }
        else
        {
            levelCanvas.SetActive(true);
            Image img = levelCanvas.transform.Find("Panel").GetComponent<Image>();
            if (currentScene.Contains("House"))
            {
                img.color = redTint;
            } 
            else 
            {
                img.color = darkTint;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {           
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        exitMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        exitMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ToggleDeathPanel()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
    }

    public void CloseDeathPanel()
    {
        deathPanel.SetActive(false);
    }
}
