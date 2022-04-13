using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 0f;
    [SerializeField] string nextLevel;
    [SerializeField] string nextLocationName;
    [SerializeField] GameObject boss;

    PlayerLocationManager locationManager;
    
    

    private void Start()
    {
        locationManager = FindObjectOfType<PlayerLocationManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Player" && boss == null)
        {
            StartCoroutine(LoadScene());
        }
        
    }

    IEnumerator LoadScene() 
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);

        if (nextLevel == "Shop") 
        {
            FindObjectOfType<CheckpointManager>().LoadNextLevel();
            yield break;
        }

        SceneManager.LoadScene(nextLevel);

        locationManager.SetLocation(nextLocationName);
    }
}
