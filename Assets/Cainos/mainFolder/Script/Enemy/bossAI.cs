using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAI : MonoBehaviour
{
    public float maxDistanceFromPlayer = 20;
    public float Range;

    public float speed = 1;

    private Transform player;
    public Animator myAnim;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < maxDistanceFromPlayer && distanceFromPlayer > Range)
        {
            myAnim.SetBool("isMoving", true);
            myAnim.SetFloat("X", (player.position.x - transform.position.x));
            myAnim.SetFloat("Y", (player.position.y - transform.position.y));
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= Range)
        {
            myAnim.SetFloat("X", (player.position.x - transform.position.x));
            myAnim.SetFloat("Y", (player.position.y - transform.position.y));
        }
        else if (distanceFromPlayer > maxDistanceFromPlayer)
        {
            myAnim.SetBool("isMoving", false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxDistanceFromPlayer);
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
