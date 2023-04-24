using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager10 : MonoBehaviour
{

    public GameObject dialogBox;

    public Text dialogText;
    public Text dialogTitle;

    private TextAsset textFile;
    private string[] textLines;

    public int currentLine;
    public int endAtLine;

    public CharacterController player;

    private bool isActive;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;

    void Start()
    {
        player = FindObjectOfType<CharacterController>();
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableDialogueBox();
        }
        else
        {
            DisableDialogueBox(); 
        }
    }

    void Update()
    {
        
        if (!isActive)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (!isTyping)
            {
                currentLine += 1;
                if (currentLine == 3 || currentLine == 5 || currentLine == 9)
                {
                    dialogTitle.text = "Bi";
                    if (currentLine > endAtLine)
                    {
                        DisableDialogueBox();
                    }
                    else
                    {
                        StartCoroutine(TextScroll(textLines[currentLine]));
                    }
                }
                else if (currentLine == 4 || currentLine == 8)
                {
                    dialogTitle.text = "Vi";
                    if (currentLine > endAtLine)
                    {
                        DisableDialogueBox();
                    }
                    else
                    {
                        StartCoroutine(TextScroll(textLines[currentLine]));
                    }
                }
                else if (currentLine == 6)
                {
                    dialogTitle.text = "Me";
                    if (currentLine > endAtLine)
                    {
                        DisableDialogueBox();
                    }
                    else
                    {
                        StartCoroutine(TextScroll(textLines[currentLine]));
                    }
                }
                else
                {
                    dialogTitle.text = "Samuel";
                    if (currentLine > endAtLine)
                    {
                        DisableDialogueBox();
                    }
                    else
                    {

                        StartCoroutine(TextScroll(textLines[currentLine]));
                    }
                }
                
            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }

    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        dialogText.text = "";
        isTyping = true;
        cancelTyping = false;
        while(isTyping && !cancelTyping && (letter <lineOfText.Length - 1)) 
        {
            dialogText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        dialogText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableDialogueBox()
    {
        dialogTitle.text = "Samuel";
        dialogBox.SetActive(true);
        isActive = true;
        player.canMove = false;
        StartCoroutine(TextScroll(textLines[currentLine]));
    }

    public void DisableDialogueBox()
    {
        dialogBox.SetActive(false);
        isActive = false;
        dialogTitle.text = "";
        player.canMove = true;  
        player.speed = 6;
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
