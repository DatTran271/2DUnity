using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_SKEUI : MonoBehaviour
{
    private BossHealth_ske BossHP2;
    public Slider healthBar1;
    //public Text HPText;
    // Start is called before the first frame update
    void Start()
    {
        BossHP2 = FindObjectOfType<BossHealth_ske>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar1.maxValue = BossHP2.maxHealth;
        healthBar1.value = BossHP2.currentHealth;
        //HPText.text =  healthMan.currentHealth + "/" + healthMan.maxHealth;
    }
}
