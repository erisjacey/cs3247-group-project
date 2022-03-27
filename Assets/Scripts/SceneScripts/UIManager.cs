using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

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
        if (SceneManager.GetActiveScene().name == "Menu") 
        {
            levelCanvas.SetActive(false);
            return;
        }
        else
        {
            levelCanvas.SetActive(true);
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
