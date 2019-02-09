using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCursor : MonoBehaviour {

    private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () {
        // Grab the mesh renderer that is on the same object as this cript
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        // We will shoot a ray in the world from the user head position and orientation
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        Animator animatorAttachedToHitObject;

        if(Physics.Raycast(headPosition,gazeDirection, out hitInfo))
        {
            // If ray casted has hit something display the cursor
            meshRenderer.enabled = true;

            // Move cursor on top of the hit object
            this.transform.position = hitInfo.point;

            // Align cursor to hit object
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

            // CUSTOM CODE TO DO SOMETHING IF AN OBJECT IS GAZED AT

            if(hitInfo.transform.GetComponent<Animator>() != null)
            {
                //Homework

                // Get the Animator Controller
                animatorAttachedToHitObject = hitInfo.transform.GetComponent<Animator>();

                // Set the Bounce boolean to true animatorAttachedToHitObject.SetBool(....what goes here?);
            }
        }
        else
        {
            // Hide cursor if no object is seen 
            meshRenderer.enabled = false;
        }
		
	}
}
