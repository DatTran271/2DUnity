using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Story1Manager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    public GameObject Story2;
    public AudioClip sound;
    public GameObject PressLMB;

    public float currentTime;
    private bool isTimeFinish;

    void Start()
    {
        textComponent.text = string.Empty;
        StartStory1();

        isTimeFinish = false;
        currentTime = 6f;
        StartCoroutine(TimeIE());
    }

    IEnumerator TimeIE()
    {
        while (currentTime >= 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            if (currentTime == 0)
            {
                PressLMB.SetActive(true);
                isTimeFinish = true;
            }
        }
        currentTime = 6f;
    }

    void Update()
    {
        if (isTimeFinish)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                    isTimeFinish = false;
                    PressLMB.SetActive(false);
                    StartCoroutine(TimeIE());
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
    }

    void StartStory1()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        SoundManager.instance.PlayClip(sound);
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        SoundManager.instance.StopClip(sound);   
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            Story2.SetActive(true);
            PressLMB.SetActive(false);
        }
    }
}
/*
 * Story Sentences
 *1. In the time after Age of Darkness, Humans have abandoned their long civilized life on the ground to avoid the hunt of ferocious creatures.
 "Living here will evade their pursuit" - with such a hopeless thought, few groups of survivors began to settle down and build an underground city.
 *
 * 
     *  
       "He" 's one of the survivors of that tragedy, from there on his memory are very vague and fragmentary he has lost his understanding of the kind of person he is.
 * 
 *  
 * 2. All he can remember is the image of a giant monster attacking his village, screams, cries echoing everywhere. 
  A woman whose face he couldn't realize suddenly hugged and hide him into the stable  . Finally, the image of that monster rushing towards that woman...
 * 
 * 3. Many, many years passed, He has the prospect to find the new path for the future of human, intead of continuing these unpredicted living days. He walks to the Gate- the place where the ground meets the underground. 
 *  And this is the beginning of his arduous and exciting journey
*/