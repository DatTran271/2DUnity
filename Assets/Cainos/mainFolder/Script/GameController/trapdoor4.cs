using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapdoor4 : MonoBehaviour
{
    public GameObject doorEnter;
    public GameObject doorExits;
    public GameObject hpboss_bear;
    public GameObject boss_bear;
    public GameObject mini_bear;
    public GameObject BGM;
    public GameObject finaldoor;

    void Start()
    {
        doorEnter.SetActive(false);
        doorExits.SetActive(true);
        hpboss_bear.SetActive(false);
        mini_bear.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doorEnter.SetActive(true);
            hpboss_bear.SetActive(true);
            boss_bear.SetActive(true);
            mini_bear.SetActive(true);
            BGM.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Boss_bear")
        {
            Destroy(doorExits);
            Destroy(doorEnter);
            Destroy(finaldoor);
            hpboss_bear.SetActive(false);
            boss_bear.SetActive(false);
            mini_bear.SetActive(false);
            BGM.SetActive(true);
        }
    }
}
