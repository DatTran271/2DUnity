using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private CharacterController player;
    private HealthPlayer health;
    private BossHealth boss_slime;
	private BossHealth_bee boss_bee;
	private BossHealth_ske boss_ske;
	private BossHealth_bat boss_bat;
	private BossHealth_bear boss_bear;

    private GoldManager gold;
    private checkHeal potion;
    public GameObject savingText;
    private void Start()
    {
        player = FindObjectOfType<CharacterController>();
        health = FindObjectOfType<HealthPlayer>();
        boss_slime = FindObjectOfType<BossHealth>();
		boss_bee = FindObjectOfType<BossHealth_bee>();
		boss_ske = FindObjectOfType<BossHealth_ske>();
		boss_bat = FindObjectOfType<BossHealth_bat>();
		boss_bear = FindObjectOfType<BossHealth_bear>();

        gold = FindObjectOfType<GoldManager>();
        potion = FindObjectOfType<checkHeal>();

        if (PlayerPrefs.GetInt("SaveManager") == 1 && PlayerPrefs.GetInt("TimetoLoad") == 1)
        {
            health.currentHealth = PlayerPrefs.GetInt("Health");
            player.getPosX = PlayerPrefs.GetFloat("playerPosX");
            player.getPosY = PlayerPrefs.GetFloat("playerPosY");
            player.transform.position = new Vector2(player.getPosX, player.getPosY);
            boss_slime.isBossSlimeDefeated = IntToBool(PlayerPrefs.GetInt("BossSlime"));
			boss_bee.isBossBeeDefeated = IntToBool(PlayerPrefs.GetInt("BossBee"));
			boss_ske.isBossSkeDefeated = IntToBool(PlayerPrefs.GetInt("BossSke"));
			boss_bat.isBossBatDefeated = IntToBool(PlayerPrefs.GetInt("BossBat"));
			boss_bear.isBossBearDefeated = IntToBool(PlayerPrefs.GetInt("BossBear"));

            gold.money = PlayerPrefs.GetInt("Gold");
            potion.healpotion = PlayerPrefs.GetInt("Potions");


            //PlayerPrefs.SetInt("TimetoLoad", 0);
            PlayerPrefs.SetInt("LoadScene", 0);
            PlayerPrefs.Save();
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Health", health.currentHealth);
        PlayerPrefs.SetFloat("playerPosX", player.transform.position.x);
        PlayerPrefs.SetFloat("playerPosY", player.transform.position.y);
        PlayerPrefs.SetInt("BossSlime", BoolToInt(boss_slime.isBossSlimeDefeated));
		PlayerPrefs.SetInt("BossBee", BoolToInt(boss_bee.isBossBeeDefeated));
		PlayerPrefs.SetInt("BossSke", BoolToInt(boss_ske.isBossSkeDefeated));
		PlayerPrefs.SetInt("BossBat", BoolToInt(boss_bat.isBossBatDefeated));
		PlayerPrefs.SetInt("BossBear", BoolToInt(boss_bear.isBossBearDefeated));

        PlayerPrefs.SetInt("Gold",gold.money);
        PlayerPrefs.SetInt("Potions",potion.healpotion);


        PlayerPrefs.SetInt("SaveManager", 1);
        PlayerPrefs.Save();

        StartCoroutine(SavingTime());
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("TimetoLoad", 1);
        PlayerPrefs.Save();
        Debug.Log("Load Game .....");
    }
    
    private int BoolToInt(bool val)
    {
        return val ? 1 : 0;
    }

    private bool IntToBool(int val)
    {
        return val == 1;
    }

    IEnumerator SavingTime()
    {
        savingText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        savingText.SetActive(false);
    }
}
