using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDummy : MonoBehaviour
{
    public float maxDistanceFromPlayer = 20;
    public float shootingRange;
    public float starttimeBtwShots;
    private float timeBtwShots;
    public float speed = 1;

    public GameObject projectile;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = starttimeBtwShots;
    }


    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
       
        if (distanceFromPlayer <= shootingRange)
        {
            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = starttimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxDistanceFromPlayer);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
