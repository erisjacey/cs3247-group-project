using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thoughts : MonoBehaviour
{
    public float timeTillMessageAppears;
    public float timeTillMessageDisappears;
    private Canvas canvas;

    void Start()
    {
        canvas = transform.Find("test").Find("Canvas").GetComponent<Canvas>();
        canvas.enabled =false;
        // textWriter.AddWriter(messageText, "Hello World!",1f);
        StartCoroutine(run());
    }
    IEnumerator run()
    {
        yield return new WaitForSecondsRealtime(timeTillMessageAppears);
        canvas.enabled = true;
        yield return new WaitForSecondsRealtime(timeTillMessageDisappears);
        canvas.enabled = false;

    }
}
