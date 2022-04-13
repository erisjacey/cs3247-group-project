using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCanvasManager : MonoBehaviour
{
    [SerializeField]
    public float durationToWait;

    private void Awake() {
        SetChildrenActive(false);
    }

    void Start()
    {
        StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        Debug.Log("Running");
        yield return new WaitForSecondsRealtime(durationToWait);
        SetChildrenActive(true);
    }

    private void SetChildrenActive(bool isActive)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }
}
