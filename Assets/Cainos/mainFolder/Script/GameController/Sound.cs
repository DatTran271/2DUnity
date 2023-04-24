using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerVolume"))
        {
            PlayerPrefs.SetFloat("PlayerVolume", 1);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }
    }
    public void SetVolumn()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("PlayerVolume", volumeSlider.value);
        Debug.Log("Save Volume");
    }
    public void LoadVolume()
    {
        PlayerPrefs.GetFloat("PlayerVolume");
        Debug.Log("Load Volume");
    }
}
