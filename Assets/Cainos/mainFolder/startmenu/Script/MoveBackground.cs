using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

	public float speed;
	private float x;
    private float Destination = -8.56f;
    private float Startpoint = 9.5f;

	// Use this for initialization
	void Start () {
		//Start = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {


		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);



		if (x <= Destination){

			x = Startpoint;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}


	}
}
