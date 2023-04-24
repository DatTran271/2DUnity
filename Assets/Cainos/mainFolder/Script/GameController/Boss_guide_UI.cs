using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_guide_UI : MonoBehaviour
{
    private BossHealth_guide BossHP2;
    public Slider healthBar1;
    //public Text HPText;
    // Start is called before the first frame update
    void Start()
    {
        BossHP2 = FindObjectOfType<BossHealth_guide>();
    }

    // Update is called once per frame
    void Update()
    {
        BossHP2 = FindObjectOfType<BossHealth_guide>();
        healthBar1.maxValue = BossHP2.maxHealth;
        healthBar1.value = BossHP2.currentHealth;
        //HPText.text =  healthMan.currentHealth + "/" + healthMan.maxHealth;
    }
}
