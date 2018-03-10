using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {
	public float speed = 5;
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Manager").GetComponent<Rotation>().isRotating())
			transform.Rotate (new Vector3(0, 0, Time.deltaTime * speed));
	}
}
