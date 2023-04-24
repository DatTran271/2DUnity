using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth_bat : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    private Animator anim;

    private bool flashActive;
    public float flashLength = 0.5f;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;

    private Rigidbody2D rb;

    public bossAI_range boss_p1;
    public bossAI_range_twoButlet boss_p2;
    public BossAI_range_manyBullet boss_p3;
    public bossAI_range_hidden boss_p4;

    public bool isInvulnerable = false;
	public bool isBossBatDefeated = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemySprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        boss_p1 = GetComponent<bossAI_range>();
        boss_p2 = GetComponent<bossAI_range_twoButlet>();
        boss_p3 = GetComponent<BossAI_range_manyBullet>();
        boss_p4 = GetComponent<bossAI_range_hidden>();
    }

    // Update is called once per frame
    void Update()
    {
		if(isBossBatDefeated == true)
        {
            Destroy(gameObject);
            Debug.Log("Boss is defeated");
        }
        if (flashActive)
        {
			
            if (flashCounter > flashLength * .99f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtBoss(int damageToGive)
    {
        if (isInvulnerable) return;

        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;

        if (currentHealth <= 350)
        {
            boss_p1.enabled = !boss_p1.enabled;
            anim.SetBool("phase2", true);
            boss_p2.enabled = !boss_p2.enabled;
        }

        if (currentHealth <= 250)
        {
            boss_p3.enabled = !boss_p3.enabled;
        }

        if (currentHealth <= 150)
        {
            boss_p2.enabled = !boss_p2.enabled;
            boss_p4.enabled = !boss_p4.enabled;
        }

        if (currentHealth <= 0)
        {
            boss_p3.enabled = !boss_p3.enabled;
            boss_p4.enabled = !boss_p4.enabled;
            anim.SetBool("isDead", true);
            StartCoroutine(EnemyActiveOff());
        }
    }

    IEnumerator EnemyActiveOff()
    {
		isBossBatDefeated = true;
        yield return new WaitForSeconds(2f);
    }
}
