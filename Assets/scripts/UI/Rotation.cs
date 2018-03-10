using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	private bool rotating;

	// Use this for initialization
	void Start () {
		rotating = false;
	}

	// 
	public void ToogleRotation() {
		rotating = !rotating;
	}

	public bool isRotating() {
		return rotating;
	}
}
