using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader_script : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 3f;
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
        // StartCoroutine(LoadLevel());
        int i = (SceneManager.GetActiveScene().buildIndex)+1;
        if(i==18)
        {
            i =0;
        }
        StartCoroutine(LoadLevel(i));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSecondsRealtime(cutsceneTime);
        transition.SetTrigger("start");
        yield return new WaitForSecondsRealtime(transitionTime);
        FindObjectOfType<PlayerLocationManager>().SetLocation("");
        SceneManager.LoadScene(levelIndex);
    }
}
