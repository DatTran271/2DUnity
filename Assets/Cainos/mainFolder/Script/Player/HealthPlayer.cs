using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    private Animator anim;

    private bool flashActive;
    public float flashLength = 0.5f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;
    private bool isDead = false;

    public GameObject damageText;
    public GameObject healText;

    public int HealAmount = 5;
    public GameObject PoisonEffectUI;
    public GameObject BurnEffectUI;

	private checkHeal cHeal;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
		cHeal = GetComponent<checkHeal>();
    }
    // Update is called once per frame
    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;

        DamageIndicator indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
        indicator.SetDamageText(damageToGive);

        if (currentHealth <= 0)
        {
            isDead = true;
            anim.SetBool("isDead", isDead);
            StartCoroutine(PlayerActiveOff());
        }
    }

    IEnumerator PlayerActiveOff()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("game_over");
    }

    public void Heal(int HealAmount)
    {
        currentHealth += HealAmount;
		HealthIndicator indicator = Instantiate(healText, transform.position, Quaternion.identity).GetComponent<HealthIndicator>();
        indicator.SetHealText(HealAmount);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
	public void HealPotion(int HealAmount)
    {
		if (currentHealth >= maxHealth)
        {
			//Debug.Log("full mau");
			cHeal.healpotion += 1;
			return;
        }
        currentHealth += HealAmount;
		HealthIndicator indicator = Instantiate(healText, transform.position, Quaternion.identity).GetComponent<HealthIndicator>();
        indicator.SetHealText(HealAmount);
		if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Health")
        {
            Heal(HealAmount);

            HealthIndicator indicator = Instantiate(healText, transform.position, Quaternion.identity).GetComponent<HealthIndicator>();
            indicator.SetHealText(HealAmount);

            other.gameObject.SetActive(false);
        }
    }

    // Add function burning player
    public void FireBurningPlayer(int damageToGive)
    {
        StartCoroutine(WaitforBurningTwiceTimes(damageToGive));
        flashActive = true;
        flashCounter = flashLength;

        DamageIndicator indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
        indicator.SetDamageText(damageToGive);

        if (currentHealth <= 0)
        {
            isDead = true;
            anim.SetBool("isDead", isDead);
            StartCoroutine(PlayerActiveOff());
        }
    }

    // Add function burning player by toxic
    public void ToxicBurningPlayer(int damageToGive)
    {
        StartCoroutine(WaitforBurningManyTimes(damageToGive));
        flashActive = true;
        flashCounter = flashLength;

        DamageIndicator indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
        indicator.SetDamageText(damageToGive);

        if (currentHealth <= 0)
        {
            isDead = true;
            anim.SetBool("isDead", isDead);
            StartCoroutine(PlayerActiveOff());
        }
    }

    // Add twice times burning 
    IEnumerator WaitforBurningTwiceTimes(int damageToGive)
    {
        currentHealth -= damageToGive;
        BurnEffectUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        BurnEffectUI.SetActive(false);
        currentHealth -= 5;
        BurnEffectUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        BurnEffectUI.SetActive(false);
        currentHealth -= 5;
    }

    // Add many times burning 
    IEnumerator WaitforBurningManyTimes(int damageToGive)
    {
        currentHealth -= damageToGive;
        PoisonEffectUI.SetActive(true);
        yield return new WaitForSeconds(1);
        for (int i = 1; i <= damageToGive; i++)
        {
            currentHealth -= i;
            yield return new WaitForSeconds(1);
        }
        PoisonEffectUI.SetActive(false);
    }

}
