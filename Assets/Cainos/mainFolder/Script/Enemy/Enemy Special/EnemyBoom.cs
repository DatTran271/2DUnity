using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoom : MonoBehaviour
{
    public GameObject explode;
    public GameObject dmgExplode;
    
    public float maxDistanceFromPlayer = 20;
    public float Range;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < maxDistanceFromPlayer && distanceFromPlayer > Range)
        {
            GetComponent<Renderer>().material.color = Color.red;
            Destroy(gameObject, 5);
        }
    }

    void OnDestroy()
    {   
        // Explode damge
        GameObject dmgExpl =  Instantiate(dmgExplode, transform.position, Quaternion.identity);
        GameObject expl = Instantiate(explode, transform.position, Quaternion.identity) as GameObject;
        
        Destroy(dmgExpl, 0.5f);
        Destroy(expl, 0.5f);
    }
}
