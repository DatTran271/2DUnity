using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseControlPlayer_range : MonoBehaviour
{
    private HealthPlayer healthMan;
    private float waitToHurt = 1f;
    public bool isTouching;
    public int damageToGive = 0;
    public GameObject hitEffect;

    void Start()
    {
        healthMan = FindObjectOfType<HealthPlayer>();
    }

  
    void Update()
    {
        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthMan.HurtPlayer(damageToGive);
                waitToHurt = 1f;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<HealthPlayer>().HurtPlayer(damageToGive);
            other.gameObject.GetComponent<CharacterController>().LoseControlPlayer();
            Destroy(effect, 0.68f);
            Destroy(gameObject);
        }
        if (other.tag == "Scene")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }
}
