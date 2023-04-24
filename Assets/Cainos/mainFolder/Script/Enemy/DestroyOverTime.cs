using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float timetoDestroy;

    void Start()
    {
        
    }

 
    void Update()
    {
        timetoDestroy -= Time.deltaTime;
        if (timetoDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
