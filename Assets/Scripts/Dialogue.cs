using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines;
    [SerializeField] TMP_Text dialogueText;

    int currentLine = 0;

    public void NextDialogueLine()
    {
        Debug.Log("SIGNAL FIRED! Current line: " + currentLine);

        if (currentLine >= timelineTextLines.Length)
        {
            Debug.Log("NO MORE DIALOGUE LINES!");
            return;
        }

        Debug.Log("Changing text to: " + timelineTextLines[currentLine]);

        dialogueText.text = timelineTextLines[currentLine];

        currentLine++;
    }
}