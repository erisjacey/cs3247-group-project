using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message_Assistant : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextWriter textWriter;
    public float timeTillMessageAppears;
    public float messageInterval;
    private Text text1;
    private Text text2;
    private Text text3;
    private Text text4;
    private Text text5;

    private void Awake(){
        text1 = transform.Find("Text1").GetComponent<Text>();
        text2 = transform.Find("Text2").GetComponent<Text>();
        text3 = transform.Find("Text3").GetComponent<Text>();
        text4 = transform.Find("Text4").GetComponent<Text>();
        text5 = transform.Find("Text5").GetComponent<Text>();
    }
    void Start()
    {
        StartCoroutine(run());
    }
    IEnumerator run()
    {
        yield return new WaitForSecondsRealtime(timeTillMessageAppears);
        textWriter.AddWriter(text1, "They are just people",0.05f,true);
        yield return new WaitForSecondsRealtime(messageInterval);
        textWriter.AddWriter(text2, ", like me",0.05f,true);
        yield return new WaitForSecondsRealtime(messageInterval);
        textWriter.AddWriter(text3, "There is nothing to fear",0.05f,true);
        yield return new WaitForSecondsRealtime(messageInterval);
        textWriter.AddWriter(text4, "I can do this",0.05f,true);
        yield return new WaitForSecondsRealtime(messageInterval);
        text1.enabled = false;
        text2.enabled = false;
        text3.enabled = false;
        text4.enabled = false;
        textWriter.AddWriter(text5, "I CAN DO THIS",0.05f,true);
    }
}
