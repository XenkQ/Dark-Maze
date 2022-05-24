using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControlsVisualEffects
{
    public void ChangeFontSize(TextMeshProUGUI text, int newSize)
    {
        text.fontSize = newSize;
    }

    public void ChangeFontSize(TextMeshPro text, int newSize)
    {
        text.fontSize = newSize;
    }

    public void ChangeFontSize(Text text, int newSize)
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

    public void ChangeFontColor(Text text, Color32 color)
    {
        text.color = color;
    }

    public void ResetAllTextColors(TextMeshProUGUI[] texts, Color32 dafultColor)
    {
        foreach(TextMeshProUGUI text in texts)
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

    public void ResetAllTextColors(Text[] texts, Color32 dafultColor)
    {
        foreach (Text text in texts)
        {
            text.color = dafultColor;
        }
    }
}
