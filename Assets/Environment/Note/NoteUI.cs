using UnityEngine;
using TMPro;

public class NoteUI : MonoBehaviour
{
    [SerializeField] private GameObject noteContent;
    [SerializeField] private TextMeshProUGUI contentText;

    public void ActiveContentWithNewText(string text)
    {
        ActiveContent();
        SetText(text);
    }

    private void ActiveContent()
    {
        noteContent.SetActive(true);
    }

    private void SetText(string text)
    {
        contentText.text = text;
    }

    public void DisableContent()
    {
        noteContent.SetActive(false);
    }
}
