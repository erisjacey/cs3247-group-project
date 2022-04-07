using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prologue : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    public float timeTillMessageAppears;
    public float messageInterval;
    private Text text1;
    private Text text2;

    private void Awake(){
        text1 = transform.Find("Text1").GetComponent<Text>();
        text2 = transform.Find("Text2").GetComponent<Text>();
        
    }
    void Start()
    {
        StartCoroutine(run());
    }
    IEnumerator run()
    {
        yield return new WaitForSecondsRealtime(timeTillMessageAppears);
        textWriter.AddWriter(text1, "<player> has been feeling really down recently with many things in life going wrong.",0.05f,true);
        yield return new WaitForSecondsRealtime(messageInterval);
        textWriter.AddWriter(text2, "Thus <player> seeks the help of a local therapist who has been known for her unorthodox methods...",0.05f,true);

    }
}
