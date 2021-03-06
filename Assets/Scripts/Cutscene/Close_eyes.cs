using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Close_eyes : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 3f;
    public float closeEyesTime;
    public float fromEyesCloseToEndLevel;
    public float timeTillCloseEyes;
    // Start is called before the first frame update
    void Start()
    {
        LoadNextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadNextLevel()
    {
        // StartCoroutine(LoadLevel(1));
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        int i = (SceneManager.GetActiveScene().buildIndex) + 1;
        if (i == 18)
        {
            i = 0;
        }
        StartCoroutine(LoadLevel(i));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSecondsRealtime(timeTillCloseEyes);
        transition.SetTrigger("close");
        yield return new WaitForSecondsRealtime(closeEyesTime);
        transition.SetTrigger("open");
        yield return new WaitForSecondsRealtime(fromEyesCloseToEndLevel);
        transition.SetTrigger("start");
        yield return new WaitForSecondsRealtime(transitionTime);
        FindObjectOfType<PlayerLocationManager>().SetLocation("");
        SceneManager.LoadScene(levelIndex);
    }
}
