using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{

    private static Tooltip instance;

    [SerializeField]
    private Camera uiCamera;

    private Text tooltipText;
    private RectTransform backgroundRectTransform;

    private void Awake()
    {
        instance = this;
        backgroundRectTransform = transform.Find("background").GetComponent<RectTransform>();
        tooltipText = transform.Find("text").GetComponent<Text>();

        ShowTooltip("Hover over items for description");
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
        transform.localPosition = localPoint + new Vector2(100, -25);
    }
    private void ShowTooltip(string tooltipString)
    {
        gameObject.SetActive(true);

        tooltipText.text = tooltipString;
        // float textPaddingSize = 0.2f;
        // Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth, tooltipText.preferredHeight);
        // backgroundRectTransform.sizeDelta = backgroundSize;
    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public static void ShowTooltip_Static(string tooltipString)
    {
        instance.ShowTooltip(tooltipString);
    }

    public static void HideTooltip_Static()
    {
        instance.HideTooltip();
    }
}
