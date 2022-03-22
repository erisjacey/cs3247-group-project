using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLocationManager : MonoBehaviour
{
    [SerializeField] int locationIndex = -1;
    [SerializeField] List<GameObject> spawnLocations = new List<GameObject>();
    
    // Singleton pattern for PlayerLocationManager
    private void Awake() 
    {
        int locationManagerCount = FindObjectsOfType<PlayerLocationManager>().Length;

        if (locationManagerCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Debug.Log("OnSceneLoaded: " + scene.name);
        // Debug.Log(mode);

        // If locationIndex is not set, do not adjust player location
        if (locationIndex < 0) return;
        if (SceneManager.GetActiveScene().name == "Menu") return;

        if (FindObjectsOfType<PlayerController>().Length == 0) return;

        GameObject player = FindObjectOfType<PlayerController>().gameObject;
        player.transform.position = spawnLocations[locationIndex].transform.position;
    }


    public void SetLocationIndex(int newIndex)
    {
        locationIndex = newIndex;
    }
}
