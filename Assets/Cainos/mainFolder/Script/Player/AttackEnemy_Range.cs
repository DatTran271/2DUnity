using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackEnemy_Range : MonoBehaviour
{
    public int damageToGive = 2;
    public GameObject hitEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Dummy")
        {
            HealthEnemy eHealthMan;
            eHealthMan = other.gameObject.GetComponent<HealthEnemy>();
            eHealthMan.HurtEnemy(damageToGive);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(gameObject);

        } 
        if(other.tag == "Scene"){
            Destroy(gameObject);
        }
        if (other.tag == "Boss")
        {
            BossHealth healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth>();
            healthBoss.HurtBoss(damageToGive);
            Destroy(gameObject);
        }
        if (other.tag == "Boss_ske")
        {
            BossHealth_ske healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth_ske>();
            healthBoss.HurtBoss(damageToGive);
            Destroy(gameObject);
        }
		if (other.tag == "Boss_octopus")
        {
            BossHealth_octopus healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth_octopus>();
            healthBoss.HurtBoss(damageToGive);
            Destroy(gameObject);
        }
        if (other.tag == "Boss_bat")
        {
            BossHealth_bat healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth_bat>();
            healthBoss.HurtBoss(damageToGive);
            Destroy(gameObject);
        }
        if (other.tag == "Boss_bear")
        {
            BossHealth_bear healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth_bear>();
            healthBoss.HurtBoss(damageToGive);
            Destroy(gameObject);
        }
        if (other.tag == "Boss_Guide")
        {
            BossHealth_guide healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth_guide>();
            healthBoss.HurtBoss(damageToGive);
            Destroy(gameObject);
        }
        if (other.tag == "Boss_bee")
        {
            BossHealth_bee healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth_bee>();
            healthBoss.HurtBoss(damageToGive);
            Destroy(gameObject);
        }
    }
}
