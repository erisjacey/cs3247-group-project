using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSessionSingleton : MonoBehaviour
{
    // Singleton pattern for PlayerLocationManager
    private void Awake() 
    {
        int gameSessionCount = FindObjectsOfType<GameSessionSingleton>().Length;

        if (gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu") Destroy(gameObject);
    }
}
