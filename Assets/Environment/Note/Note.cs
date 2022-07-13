using UnityEngine;
using TMPro;

public class Note : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] [TextArea(minLines: 20, maxLines: 24)] private string text;
    public string Text { get { return text; } }

    private void Awake()
    {
        SetText(text);
    }

    public void SetText(string text)
    {
        textComponent.text = text;
    }
}
