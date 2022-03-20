using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLocationManager : MonoBehaviour
{
    [SerializeField] int locationIndex = 0;
    [SerializeField] List<GameObject> spawnLocations = new List<GameObject>();
    
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

        GameObject player = FindObjectOfType<PlayerController>().gameObject;
        player.transform.position = spawnLocations[locationIndex].transform.position;
    }


    public void SetLocationIndex(int newIndex)
    {
        locationIndex = newIndex;
    }
}
