using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWave : MonoBehaviour
{
    public GameObject explode;
    public GameObject effectExplode;
    
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 0);
    }

    void OnDestroy()
    {   
        // Explode damge
        GameObject eftExplode =  Instantiate(effectExplode, transform.position, Quaternion.identity);
        GameObject expl = Instantiate(explode, transform.position, Quaternion.identity) as GameObject;
        
        Destroy(eftExplode, 0.5f);
        Destroy(expl, 0.5f);
    }
}
