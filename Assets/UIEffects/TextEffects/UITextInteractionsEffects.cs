using UnityEngine;
using TMPro;

public class UITextInteractionsEffects : MonoBehaviour
{
    [SerializeField] [ColorUsage(true)] private Color32 defaultColor;
    [SerializeField] [ColorUsage(true)] private Color32 interactionColor;

    [SerializeField] private float defaultTextSize;
    [SerializeField] private float textSizeAfterInteraction;

    [SerializeField] private TextMeshProUGUI[] allTextToRestart;

    public void OnTextEnterEffect(TextMeshProUGUI buttonText)
    {
        ChangeFontColor(buttonText, interactionColor);
        ChangeFontSize(buttonText, textSizeAfterInteraction);
    }

    public void OnTextExitEffect(TextMeshProUGUI buttonText)
    {
        ChangeFontColor(buttonText, defaultColor);
        ChangeFontSize(buttonText, defaultTextSize);
    }

    public void ChangeFontSize(TextMeshProUGUI text, float newSize)
    {
        text.fontSize = newSize;
    }

    public void ChangeFontColor(TextMeshProUGUI text, Color32 color)
    {
        text.faceColor = color;
    }

    public void ResetAllTextColors()
    {
        foreach (TextMeshProUGUI text in allTextToRestart)
        {
            text.faceColor = defaultColor;
        }
    }
}
