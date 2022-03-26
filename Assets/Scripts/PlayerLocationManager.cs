using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLocationManager : MonoBehaviour
{
    [SerializeField] int locationIndex = -1;
    [SerializeField] List<GameObject> spawnLocations = new List<GameObject>();

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
        if (SceneManager.GetActiveScene().name == "Menu") {
            locationIndex = -1;
            return;
        }
        if (FindObjectsOfType<PlayerController>().Length == 0) return;

        Debug.Log("loaded player at: " + locationIndex);
        GameObject player = FindObjectOfType<PlayerController>().gameObject;
        player.transform.position = spawnLocations[locationIndex].transform.position;
    }


    public void SetLocationIndex(int newIndex)
    {
        locationIndex = newIndex;
    }
}
