using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private SaveManager save;

    void Start()
    {
        save = FindObjectOfType<SaveManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void SaveGame()
    {
        save.SaveGame();
        PlayerPrefs.SetInt("LoadScene", 1);
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Saved Game ...........!");
        Resume();
    }
    
    public void QuitGame()
    {
        //save.SaveGame();
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        //Application.Quit();
    }
}
