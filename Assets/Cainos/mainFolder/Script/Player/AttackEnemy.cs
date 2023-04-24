using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public int damageToGive = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Dummy")
        {
            HealthEnemy eHealthMan;
            eHealthMan = other.gameObject.GetComponent<HealthEnemy>();
            eHealthMan.HurtEnemy(damageToGive);

        }
        if (other.tag == "Boss")
        {
            BossHealth healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth>();
            healthBoss.HurtBoss(damageToGive);

        }
		if (other.tag == "Boss_ske")
        {
            BossHealth_ske healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth_ske>();
            healthBoss.HurtBoss(damageToGive);  
        }
		if (other.tag == "Boss_octopus")
        {
            BossHealth_octopus healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth_octopus>();
            healthBoss.HurtBoss(damageToGive);
        }
        if (other.tag == "Boss_bat")
        {
            BossHealth_bat healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth_bat>();
            healthBoss.HurtBoss(damageToGive);
        }
        if (other.tag == "Boss_bear")
        {
            BossHealth_bear healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth_bear>();
            healthBoss.HurtBoss(damageToGive);
        }
        if (other.tag == "Boss_Guide")
        {
            BossHealth_guide healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth_guide>();
            healthBoss.HurtBoss(damageToGive);
        }
        if (other.tag == "Boss_bee")
        {
            BossHealth_bee healthBoss;
            healthBoss = other.gameObject.GetComponent<BossHealth_bee>();
            healthBoss.HurtBoss(damageToGive);
        }
    }
}
