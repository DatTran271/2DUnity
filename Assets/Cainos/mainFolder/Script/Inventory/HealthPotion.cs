using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
	public GameObject itemButton;
	private Inventory inventory;
	
	public GameObject player;
	public HealthPlayer heal;
	public int cHealth;
	//private HealthPlayer HP;
	void start(){
		player=GameObject.FindGameObjectWithTag("Player");
		heal.GetComponent<HealthPlayer>();
	}
	void FixedUpdate()
    {
		cHealth=heal.currentHealth;

    }
	public void Use(){
		cHealth+=10;

	}
}
