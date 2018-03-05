using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			GetComponent<Animator> ().SetBool ("SpinCube", true);
		} else {
			GetComponent<Animator> ().SetBool ("SpinCube", false);
		}
	}
}
