using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Story3Manager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    public GameObject Story4;
    public AudioClip sound;
    public GameObject PressLMB;

    public float currentTime;
    private bool isTimeFinish;

    void Start()
    {

        textComponent.text = string.Empty;
        StartStory3();

        isTimeFinish = false;
        currentTime = 8f;
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

    void StartStory3()
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
            Story4.SetActive(true);
            PressLMB.SetActive(false);
        }
        
    }

}


