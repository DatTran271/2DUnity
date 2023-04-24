using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Story4Manager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    public AudioClip sound;
    public GameObject PressLMB;

    public GameObject loadingScreen;
    public GameObject IntroScreen;
    public Slider slider;

    public float currentTime;
    private bool isTimeFinish;

    void Start()
    {

        textComponent.text = string.Empty;
        StartStory4();

        isTimeFinish = false;
        currentTime = 5f;
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

    void StartStory4()
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
            LoadLevel(2);
        }
        
    }

    //loading screen
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    //calculate progress
    IEnumerator LoadAsynchronously(int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        IntroScreen.SetActive(false);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}


