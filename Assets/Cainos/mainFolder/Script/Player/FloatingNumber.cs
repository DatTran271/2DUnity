using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumber : MonoBehaviour
{
    public float moveSpeed;
    public int damageNumber;
    public int healNumber;
    public Text displayNumber;

    void Update()
    {
        if (healNumber == 5)
        {
            displayNumber.text = "+" + healNumber;
        }
        else
        {
            displayNumber.text = "-" + damageNumber;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
    }
}
