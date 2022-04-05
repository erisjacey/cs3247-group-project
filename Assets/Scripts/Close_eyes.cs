using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_eyes : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;
    public float cutsceneTime;
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
        StartCoroutine(LoadLevel(1));
        // StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSecondsRealtime(cutsceneTime);
        transition.SetTrigger("start");
        yield return new WaitForSecondsRealtime(transitionTime);
    }
}
