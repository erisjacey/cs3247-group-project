using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 0f;
    [SerializeField] string nextLevel;
    [SerializeField] string nextLocationName;

    PlayerLocationManager locationManager;

    private void Start()
    {
        locationManager = FindObjectOfType<PlayerLocationManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene() 
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        SceneManager.LoadScene(nextLevel);

        locationManager.SetLocation(nextLocationName);
    }
}
