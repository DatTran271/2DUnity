using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHidden : MonoBehaviour
{
    public float maxDistanceFromPlayer = 20;
    public float shootingRange;
    public float starttimeBtwShots;
    private float timeBtwShots;
    public float speed = 1;

    public Transform spawnPos;
    private Transform player;
    public Animator myAnim;
    public GameObject projectile;

    void Start()
    {
        spawnPos.parent = null;
        myAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = starttimeBtwShots;
    }


    void Update()
    {   
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < maxDistanceFromPlayer && distanceFromPlayer > shootingRange)
        {
            myAnim.SetBool("isMoving", true);
            myAnim.SetBool("isAttack", false);
            myAnim.SetFloat("X", (player.position.x - transform.position.x));
            myAnim.SetFloat("Y", (player.position.y - transform.position.y));
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().color = new Color (1,1,1,1);
        }
        else if (distanceFromPlayer <= shootingRange)
        {
            if (timeBtwShots <= 0)
            {
                myAnim.SetBool("isAttack", true);
                myAnim.SetFloat("X", (player.position.x - transform.position.x));
                myAnim.SetFloat("Y", (player.position.y - transform.position.y));
                Instantiate(projectile, transform.position, Quaternion.identity);
                
                timeBtwShots = starttimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        else if (distanceFromPlayer > maxDistanceFromPlayer)
        {
            myAnim.SetFloat("X", (spawnPos.position.x - transform.position.x));
            myAnim.SetFloat("Y", (spawnPos.position.y - transform.position.y));
            transform.position = Vector3.MoveTowards(transform.position, spawnPos.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, spawnPos.position) == 0)
            {
                myAnim.SetBool("isMoving", false);
                myAnim.SetBool("isAttack", false);
            }
            GetComponent<SpriteRenderer>().color = new Color (1,1,1,0.1f);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxDistanceFromPlayer);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
