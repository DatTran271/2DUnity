using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController_Top : MonoBehaviour
{
    GameObject target;
    private float speed = 7;
    Rigidbody2D bulletRB;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("PointTop");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject,4);
    }
}
