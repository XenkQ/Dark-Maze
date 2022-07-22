using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInteractionsEffects : MonoBehaviour
{
    [SerializeField] [ColorUsage(true)] private Color32 deafultColor;
    public Color32 DeafultColor { get { return deafultColor; } }
    [SerializeField] [ColorUsage(true)] private Color32 interactionColor;
    public Color32 InteractionColor { get { return interactionColor; } }
    [SerializeField] private float deafultTextSize;
    public float DeafultTextSize { get { return deafultTextSize; } }
    [SerializeField] private float textSizeAfterInteraction;
    public float TextSizeAfterInteraction { get { return textSizeAfterInteraction; } }

    public void OnTextEnterEffect(TextMeshProUGUI buttonText)
    {
        ChangeFontColor(buttonText, interactionColor);
        ChangeFontSize(buttonText, textSizeAfterInteraction);
    }

    public void OnTextEnterEffect(TextMeshPro buttonText)
    {
        ChangeFontColor(buttonText, interactionColor);
        ChangeFontSize(buttonText, textSizeAfterInteraction);
    }

    public void OnTextExitEffect(TextMeshProUGUI buttonText)
    {
        ChangeFontColor(buttonText, deafultColor);
        ChangeFontSize(buttonText, deafultTextSize);
    }

    public void OnTextExitEffect(TextMeshPro buttonText)
    {
        ChangeFontColor(buttonText, deafultColor);
        ChangeFontSize(buttonText, deafultTextSize);
    }

    public void ChangeFontSize(TextMeshProUGUI text, float newSize)
    {
        text.fontSize = newSize;
    }

    public void ChangeFontSize(TextMeshPro text, float newSize)
    {
        text.fontSize = newSize;
    }

    public void ChangeFontColor(TextMeshProUGUI text, Color32 color)
    {
        text.faceColor = color;
    }

    public void ChangeFontColor(TextMeshPro text, Color32 color)
    {
        text.faceColor = color;
    }

    public void ResetAllTextColors(TextMeshProUGUI[] texts, Color32 dafultColor)
    {
        foreach (TextMeshProUGUI text in texts)
        {
            text.faceColor = dafultColor;
        }
    }

    public void ResetAllTextColors(TextMeshPro[] texts, Color32 dafultColor)
    {
        foreach (TextMeshPro text in texts)
        {
            text.faceColor = dafultColor;
        }
    }
}
