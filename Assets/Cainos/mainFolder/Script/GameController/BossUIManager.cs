using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUIManager : MonoBehaviour
{
    private BossHealth BossHP;
    public Slider healthBar1;
    //public Text HPText;
    // Start is called before the first frame update
    void Start()
    {
        BossHP = FindObjectOfType<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar1.maxValue = BossHP.maxHealth;
        healthBar1.value = BossHP.currentHealth;
        //HPText.text =  healthMan.currentHealth + "/" + healthMan.maxHealth;
    }
}
