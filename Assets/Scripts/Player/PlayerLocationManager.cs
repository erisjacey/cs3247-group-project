using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLocationManager : MonoBehaviour
{
    [SerializeField] string locationName = "";
    [SerializeField] GameObject[] testSpawnLocations;
    [SerializeField] Vector3 pausedPosition = Vector3.zero;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If locationName is not set, do not adjust player location
        if (SceneManager.GetActiveScene().name == "Menu") 
        {
            locationName = "";
            return;
        }
        if (FindObjectsOfType<PlayerController>().Length == 0) return;

        GameObject player = FindObjectOfType<PlayerController>().gameObject;
        if (pausedPosition != Vector3.zero)
        {
            player.transform.position = pausedPosition;
            pausedPosition = Vector3.zero;
            return;
        }

        if (locationName == "") return;

        GameObject newLocation = Array.Find(testSpawnLocations, item => item.name == locationName);
        player.transform.position = newLocation.transform.position;
    }

    public void SetLocation(string newLocation)
    {
        locationName = newLocation;
    }

    public void SetPausedLocation(Vector3 newPausedPosition)
    {
        pausedPosition = newPausedPosition;
    }
}
