using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_OctoUI : MonoBehaviour
{
    private BossHealth_octopus BossHP;
    public Slider healthBar;
    //public Text HPText;
    // Start is called before the first frame update
    void Start()
    {
        BossHP = FindObjectOfType<BossHealth_octopus>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = BossHP.maxHealth;
        healthBar.value = BossHP.currentHealth;
        //HPText.text =  healthMan.currentHealth + "/" + healthMan.maxHealth;
    }
}
