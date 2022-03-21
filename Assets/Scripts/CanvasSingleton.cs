using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasSingleton : MonoBehaviour
{
    // Singleton pattern for PlayerLocationManager
    private void Awake() 
    {
        int canvasCount = FindObjectsOfType<CanvasSingleton>().Length;

        if (canvasCount > 1)
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
