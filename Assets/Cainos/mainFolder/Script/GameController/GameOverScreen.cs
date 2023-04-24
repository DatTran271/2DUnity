using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    Text timeText;
    [SerializeField]
    float duration, currentTime;

    public GameObject loadingScreen;
    public GameObject gameOverScreen;
    private SaveManager save;
    public Slider slider;

    void Start()
    {
        timeText.text = "";
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIE());
    }

    IEnumerator TimeIE()
    {
        while (currentTime >= 0)
        {
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
            if (currentTime == 0)
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
                //LoadLevel(2);
            }
        }
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        gameOverScreen.SetActive(false);
        loadingScreen.SetActive(true);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }

}
