using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel2 : MonoBehaviour
{
    private SaveManager saveM;
    private void Start() {
        saveM = FindObjectOfType<SaveManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            saveM.SaveGame();
            SceneManager.LoadScene("map4");
        }
    }
}
