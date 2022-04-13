using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    UIManager uiManager;
    HealthManager healthManager;
    PlayerLocationManager playerLocationManager;
    string lastScene = "";
    public static bool hasSavedGame = false;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
        healthManager = GetComponentInChildren<HealthManager>();
        playerLocationManager = GetComponentInChildren<PlayerLocationManager>();
    }

    public void GameOver()
    {
        if (uiManager != null)
        {
            uiManager.ToggleDeathPanel();
        }
    }

    void CloseUI()
    {
        if (uiManager != null)
        {
            uiManager.CloseDeathPanel();
            uiManager.Resume();
        }
        Time.timeScale = 1f;
    }

    public void SaveGame()
    {
        CloseUI();

        if (FindObjectsOfType<PlayerController>().Length == 0) return;
        GameObject player = FindObjectOfType<PlayerController>().gameObject;

        playerLocationManager.SetPausedLocation(player.transform.position);

        lastScene = SceneManager.GetActiveScene().name;
        hasSavedGame = true;
    }

    public void ResumeGame()
    {   
        SceneManager.LoadScene(lastScene);
        lastScene = "";
        hasSavedGame = false;
    }

    public void ResetGame()
    {
        CloseUI();

        healthManager.ResetHealth();
        playerLocationManager.SetLocation("Shop-2");
    }
}