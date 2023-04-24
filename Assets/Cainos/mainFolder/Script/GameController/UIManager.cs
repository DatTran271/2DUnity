using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthPlayer healthMan;
    public Slider healthBar;
    //public Text HPText;
    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = healthMan.maxHealth;
        healthBar.value = healthMan.currentHealth;
        //HPText.text =  healthMan.currentHealth + "/" + healthMan.maxHealth;
    }
}
