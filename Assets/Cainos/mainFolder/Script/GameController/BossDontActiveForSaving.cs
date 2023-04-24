using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDontActiveForSaving : MonoBehaviour
{
    public GameObject bossDontUse;
    // Start is called before the first frame update
    void Start()
    {
        bossDontUse.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
