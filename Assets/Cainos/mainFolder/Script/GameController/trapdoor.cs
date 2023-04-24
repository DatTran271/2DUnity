using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapdoor : MonoBehaviour
{   
    public GameObject doorEnter;
    public GameObject doorExits;
    public GameObject hpboss_slime;
    public GameObject boss_slime;
    public GameObject mini_slime;
    public GameObject BGM;
    public GameObject finaldoor;

    void Start() 
    {
        doorEnter.SetActive(false);
        doorExits.SetActive(true);
        hpboss_slime.SetActive(false);
        mini_slime.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doorEnter.SetActive(true);
            hpboss_slime.SetActive(true);
            boss_slime.SetActive(true);
            mini_slime.SetActive(true);
            BGM.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Boss")
        {
            Destroy(doorExits);
            Destroy(doorEnter);
            Destroy(finaldoor);
            hpboss_slime.SetActive(false);
            boss_slime.SetActive(false);
            mini_slime.SetActive(false);
            BGM.SetActive(true);
        }
    }
}
