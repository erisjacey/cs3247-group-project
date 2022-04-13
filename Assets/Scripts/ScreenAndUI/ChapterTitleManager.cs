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

    private Image textBg;
    private Text text1;
    private Text text2;

    private void Awake() {
        textBg = transform.Find("TextBackground").GetComponent<Image>();
        text1 = transform.Find("Text1").GetComponent<Text>();
        text2 = transform.Find("Text2").GetComponent<Text>(); 
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

        // Display text2: event, time period
        yield return new WaitForSecondsRealtime(messageInterval);
        textWriter.AddWriter(text2, string.Format("{0}, {1}", location, period), 0.05f, true);

        // Disable texts
        yield return new WaitForSecondsRealtime(textTotalDuration);
        textBg.gameObject.SetActive(false);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
    }
}
