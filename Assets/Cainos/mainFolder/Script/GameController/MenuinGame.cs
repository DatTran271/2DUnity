using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuinGame : MonoBehaviour
{
    public GameObject dialogObject;

    public void PlayNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("IntroScene");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.GetInt("TimetoLoad") == 1 && PlayerPrefs.GetInt("LoadScene") == 1)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        }
        else
        {
            dialogObject.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
