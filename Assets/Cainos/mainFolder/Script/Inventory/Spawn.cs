using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    private Transform player;
    public GameObject item;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnItem() {
        Vector2 playerP=new Vector2(player.position.x+Random.Range(-4f,4f),player.position.y+Random.Range(-4f,4f));
		Instantiate(item,playerP,Quaternion.identity);
    }
}
