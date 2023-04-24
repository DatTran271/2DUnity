using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler_point : MonoBehaviour
{
    GameObject target;
    private float speed = 7;
    Rigidbody2D bulletRB;

    public int numPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (numPoint == 1) {
            bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Point_1");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject,4);
        }else if (numPoint == 2) {
            bulletRB = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Point_2");
            Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
            bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
            Destroy(this.gameObject,4);
        }else if (numPoint == 3) {
            bulletRB = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Point_3");
            Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
            bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
            Destroy(this.gameObject,4);
        }else if (numPoint == 4) {
            bulletRB = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Point_4");
            Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
            bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
            Destroy(this.gameObject,4);
        }else if (numPoint == 5) {
            bulletRB = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("PointTop");
            Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
            bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
            Destroy(this.gameObject,4);
        }else if (numPoint == 6) {
            bulletRB = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("PointBottom");
            Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
            bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
            Destroy(this.gameObject,4);
        }
    }
}
