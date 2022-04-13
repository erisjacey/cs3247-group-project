using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterTitleManager : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    public float timeTillMessageAppears;
    public float messageInterval;
    public float textTotalDuration;

    // Chapter parameters
    public string chapterNumber;
    public string chapterTitle;
    public string location;
    public string period;

    private Text text1;
    private Text text2;
    private Text text3;

    private void Awake() {
        text1 = transform.Find("Text1").GetComponent<Text>();
        text2 = transform.Find("Text2").GetComponent<Text>();
        text3 = transform.Find("Text3").GetComponent<Text>();       
    }

    void Start()
    {
        StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        // Display text1: chapter title
        yield return new WaitForSecondsRealtime(timeTillMessageAppears);
        textWriter.AddWriter(text1, string.Format("Chapter {0}: {1}", chapterNumber, chapterTitle), 0.05f, true);

        // Display text2: event
        yield return new WaitForSecondsRealtime(messageInterval);
        textWriter.AddWriter(text2, string.Format("{0}", location), 0.05f, true);

        // Display text3: time period
        yield return new WaitForSecondsRealtime(messageInterval);
        textWriter.AddWriter(text3, string.Format("{0}", period), 0.05f, true);

        // Disable texts
        yield return new WaitForSecondsRealtime(textTotalDuration);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
    }
}
