using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLocationManager : MonoBehaviour
{
    [SerializeField] string locationName = "";
    [SerializeField] GameObject[] testSpawnLocations;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Debug.Log("OnSceneLoaded: " + scene.name);
        // Debug.Log(mode);

        // If locationName is not set, do not adjust player location
        if (locationName == "") return;

        if (SceneManager.GetActiveScene().name == "Menu") 
        {
            locationName = "";
            return;
        }
        if (FindObjectsOfType<PlayerController>().Length == 0) return;

        GameObject newLocation = Array.Find(testSpawnLocations, item => item.name == locationName);
        GameObject player = FindObjectOfType<PlayerController>().gameObject;
        player.transform.position = newLocation.transform.position;
    }

    public void SetLocation(string newLocation)
    {
        locationName = newLocation;
    }
}
