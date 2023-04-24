using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapdoor3 : MonoBehaviour
{
    public GameObject doorEnter;
    public GameObject doorExits;
    public GameObject hpboss_bat;
    public GameObject boss_bat;
    public GameObject mini_bat;
    public GameObject BGM;
    public GameObject finaldoor;

    void Start()
    {
        doorEnter.SetActive(false);
        doorExits.SetActive(true);
        hpboss_bat.SetActive(false);
        mini_bat.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doorEnter.SetActive(true);
            hpboss_bat.SetActive(true);
            boss_bat.SetActive(true);
            mini_bat.SetActive(true);
            BGM.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Boss_bat")
        {
            Destroy(doorExits);
            Destroy(doorEnter);
            Destroy(finaldoor);
            hpboss_bat.SetActive(false);
            boss_bat.SetActive(false);
            mini_bat.SetActive(false);
            BGM.SetActive(true);
        }
    }
}
