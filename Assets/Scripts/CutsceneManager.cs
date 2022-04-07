using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 3f;
    public float cutsceneTime;
    public string nextScene;

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
<<<<<<< HEAD:Assets/Scripts/cutscene_scripts/LevelLoader_script.cs
        // StartCoroutine(LoadLevel());
        int i = (SceneManager.GetActiveScene().buildIndex)+1;
        if(i==17)
        {
            i =0;
        }
        StartCoroutine(LoadLevel(i));
=======
        StartCoroutine(LoadLevel());
        // StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
>>>>>>> main:Assets/Scripts/CutsceneManager.cs
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSecondsRealtime(cutsceneTime);
        transition.SetTrigger("start");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(nextScene);
    }
}
