using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpointController : MonoBehaviour
{
    private SaveManager saveM;

    private void Start()
    {
        saveM = FindObjectOfType<SaveManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            saveM.SaveGame();
            PlayerPrefs.SetInt("LoadScene", 1);
            PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
            gameObject.SetActive(false);
        }
    }
}
