using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapdoor5 : MonoBehaviour
{
    public GameObject doorEnter;
    public GameObject doorExits;
    public GameObject hpboss_octo;
    public GameObject boss_octo;
    public GameObject mini_octo;
    public GameObject BGM;
    public GameObject finalboss;

    void Start()
    {
        doorEnter.SetActive(false);
        doorExits.SetActive(true);
        hpboss_octo.SetActive(false);
        mini_octo.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doorEnter.SetActive(true);
            hpboss_octo.SetActive(true);
            boss_octo.SetActive(true);
            mini_octo.SetActive(true);
            BGM.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Boss_octopus")
        {
            Destroy(doorExits);
            Destroy(doorEnter);
            hpboss_octo.SetActive(false);
            boss_octo.SetActive(false);
            mini_octo.SetActive(false);
            BGM.SetActive(true);
            finalboss.SetActive(true);
        }
    }
}
