using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 0f;
    [SerializeField] string nextLevel;
    [SerializeField] int nextLocationIndex;

    PlayerLocationManager locationManager;

    private void Start()
    {
        locationManager = FindObjectOfType<PlayerLocationManager>();
        Debug.Log(locationManager);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene() 
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        SceneManager.LoadScene(nextLevel);

        locationManager.SetLocationIndex(nextLocationIndex);
    }

    IEnumerator LoadNextScene() 
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
