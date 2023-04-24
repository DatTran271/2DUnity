using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour
{

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public DialogueManager theTextBox;

    public bool requireButtonPress;
    private bool waitForPress;
    public GameObject boss;
    public GameObject self;

    void Start()
    {
        theTextBox = FindObjectOfType<DialogueManager>();    
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
            boss.SetActive(true);
            waitForPress = false;
            Destroy(self);
            return;
            
        }
    }
}
