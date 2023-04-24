using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine7 : MonoBehaviour
{

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public DialogueManager7 theTextBox;

    public bool requireButtonPress;
    private bool waitForPress;

    void Start()
    {
        theTextBox = FindObjectOfType<DialogueManager7>();    
    }

    void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.E))
        {
            waitForPress = false;
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableDialogueBox();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }

            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableDialogueBox();

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theTextBox.DisableDialogueBox();
            waitForPress = false;
            return;
        }
    }
}
