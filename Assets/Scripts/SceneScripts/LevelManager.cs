using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    UIManager uiManager;

    private void Awake()
    {
        if (LevelManager.instance == null) instance = this;
        else Destroy(gameObject);
    }

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

    public void RestartGame()
    {
        if (uiManager != null)
        {
            uiManager.CloseDeathPanel();
            uiManager.Resume();
        }

        GetComponentInChildren<HealthManager>().ResetHealth();
        GetComponentInChildren<PlayerLocationManager>().SetLocation("Tutorial");
        Time.timeScale = 1f;
    }
}
