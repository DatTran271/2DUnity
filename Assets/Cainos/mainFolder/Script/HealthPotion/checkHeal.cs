using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkHeal : MonoBehaviour
{
	//HealthPotionManager
    public int healpotion;
	public GameObject slothealth;
	public Text HealthPotionNumber;
	
	void Start(){
		HealthPotionNumber.text=healpotion.ToString();
	}

	void FixedUpdate(){
		healpotion = healpotion;
	}
    
    void Update()
    {
        if(healpotion<=0)
		{
			slothealth.SetActive(false);
		}
		else
		{
			slothealth.SetActive(true);
		}
    }
	
	public void AddPotion(int number)
	{
		healpotion += number;
		HealthPotionNumber.text=healpotion.ToString();
	}
	
	public void deheal()
    {
		int n = 1;
        healpotion=healpotion-n;
		HealthPotionNumber.text=healpotion.ToString();
    }
	
	public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HealthPotion")
        {
			int number = 1;
            AddPotion(number);

            other.gameObject.SetActive(false);
        }
    }
}
