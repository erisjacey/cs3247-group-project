using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    UIManager uiManager;
    string lastScene = "";

    private void Start()
    {
        uiManager = GetComponent<UIManager>();
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

        GetComponentInChildren<PlayerLocationManager>().SetPausedLocation(player.transform.position);

        lastScene = SceneManager.GetActiveScene().name;
    }

    public void ResumeGame()
    {   
        SceneManager.LoadScene(lastScene);
        lastScene = "";
    }

    public void ResetGame()
    {
        CloseUI();

        GetComponentInChildren<HealthManager>().ResetHealth();
        GetComponentInChildren<PlayerLocationManager>().SetLocation("Shop-2");
    }
}