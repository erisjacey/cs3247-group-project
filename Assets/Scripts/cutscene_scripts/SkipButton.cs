using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    [SerializeField]
    public PlayableDirector playableDirector;

    public Animator transition;
    public float transitionTime = 3f;

    public void Play()
    {

        int i = (SceneManager.GetActiveScene().buildIndex) + 1;
        if (i == 18)
        {
            i = 0;
        }
        StartCoroutine(LoadLevel(i));

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSecondsRealtime(transitionTime);
        FindObjectOfType<PlayerLocationManager>().SetLocation("");
        SceneManager.LoadScene(levelIndex);
    }

}
