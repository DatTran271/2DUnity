using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapdoor2 : MonoBehaviour
{
    public GameObject doorEnter;
    public GameObject doorExits;
    public GameObject hpboss_ske;
    public GameObject boss_ske;
    public GameObject mini_ske;
    public GameObject BGM;
    public GameObject finaldoor;

    void Start()
    {
        doorEnter.SetActive(false);
        doorExits.SetActive(true);
        hpboss_ske.SetActive(false);
        mini_ske.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doorEnter.SetActive(true);
            hpboss_ske.SetActive(true);
            boss_ske.SetActive(true);
            mini_ske.SetActive(true);
            BGM.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Boss_ske")
        {
            Destroy(doorExits);
            Destroy(doorEnter);
            Destroy(finaldoor);
            hpboss_ske.SetActive(false);
            boss_ske.SetActive(false);
            mini_ske.SetActive(false);
            BGM.SetActive(true);
        }
    }
}
