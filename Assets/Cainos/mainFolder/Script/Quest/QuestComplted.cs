using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestComplted : MonoBehaviour
{
	public GameObject NPC1;
	public GameObject NPC2;
	private int gems;
	public GameObject collectText;
	void Start()
    {
        gems = 0;
    }
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("item"))
		{
			gems += 1;
			DamageIndicator indicator = Instantiate(collectText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
			indicator.SetItemText("crystal");
			Destroy(other.gameObject);
			if(gems>=2){
				gems=0;
				NPC1.SetActive(false);
				NPC2.SetActive(true);
			}
		}
	}
}
