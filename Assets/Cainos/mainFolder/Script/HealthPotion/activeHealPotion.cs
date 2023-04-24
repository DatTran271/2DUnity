using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeHealPotion : MonoBehaviour
{
	public int healpotion1;
    // Start is called before the first frame update
    
	public void start(){
		
	}
	public void Update(){
		
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
            //healpotion1=healpotion1+1;
			Destroy(gameObject);
		}
	}
	
}
