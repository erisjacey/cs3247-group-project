using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingCutscene : MonoBehaviour
{
[SerializeField] private TextWriter textWriter;
    public float timeTillMessageAppears;
    public float messageInterval;
    private Text text1;
    private Text text2;
    private Text text3;
    private Text text4;
    private Text text5;
    private Text text6;

    private void Awake(){
        text1 = transform.Find("Text1").GetComponent<Text>();
        text2 = transform.Find("Text2").GetComponent<Text>();
        text3 = transform.Find("Text3").GetComponent<Text>();
        text4 = transform.Find("Text4").GetComponent<Text>();
        text5 = transform.Find("Text5").GetComponent<Text>();
        text6 = transform.Find("Text6").GetComponent<Text>();
        
    }
    void Start()
    {
        StartCoroutine(run());
    }
    IEnumerator run()
    {
        yield return new WaitForSecondsRealtime(timeTillMessageAppears);
        textWriter.AddWriter(text1, "As <player> found closure...",0.05f,true);
        yield return new WaitForSecondsRealtime(messageInterval);
        textWriter.AddWriter(text2, "<player> returned to his everyday life",0.05f,true);
        yield return new WaitForSecondsRealtime(messageInterval);
        textWriter.AddWriter(text3, "brimming with optimism and positivity",0.05f,true);
        yield return new WaitForSecondsRealtime(messageInterval);
        yield return new WaitForSecondsRealtime(messageInterval);
        text1.enabled = false;
        text2.enabled = false;
        text3.enabled = false;
        textWriter.AddWriter(text4, "However are traumas really\nresolved this easily...?",0.05f,true);
        yield return new WaitForSecondsRealtime(messageInterval);
        yield return new WaitForSecondsRealtime(messageInterval);
        yield return new WaitForSecondsRealtime(messageInterval);
        text4.enabled = false;
        textWriter.AddWriter(text5, "~THE END~",0.05f,true);
        yield return new WaitForSecondsRealtime(messageInterval/2);
        textWriter.AddWriter(text6, "Credits\n<FILL IN YOUR NAMES>\nLucas",0.05f,true);
    }
}
