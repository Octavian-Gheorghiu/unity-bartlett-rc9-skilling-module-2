using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchitectureCommands : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ArchitectureFuntion()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
