using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public Text GoldText;
	public int money;
	public GameObject damageText;
	public GameObject healText;
	
    public GameObject item;
	
	void Start(){
		GoldText.text=money.ToString();
	}
	public void AddMoney(int addAmount)
	{
		money += addAmount;
		GoldText.text = money.ToString();
	}
    
	public void MinusMoney()
	{
		int price = 30;
		if(money >= price)
		{
			money -= price;
			DamageIndicator indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
			indicator.SetDamageText(price);
			GoldText.text = money.ToString();
			Vector2 playerP=new Vector2(transform.position.x+Random.Range(-2f,2f),transform.position.y+Random.Range(-2f,2f));
			Instantiate(item,playerP,Quaternion.identity);
		}
		else{
			DamageIndicator indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
			indicator.SetOutOfMoney();
		} 
	}
	
	public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Gem")
        {
			int GemAmount = 7;
            AddMoney(GemAmount);

            HealthIndicator indicator = Instantiate(healText, transform.position, Quaternion.identity).GetComponent<HealthIndicator>();
            indicator.SetHealText(GemAmount);

            other.gameObject.SetActive(false);
        }
    }
	
}
