using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GazeGestureManager : MonoBehaviour {

    public static GazeGestureManager Instance { get; private set; }

    // A variable that represents the hologram that is curently seen
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recogniser;

    // Functtion that is run before the game starts
    private void Awake()
    {
        Instance = this;

        // Set up a GestureRecogniser to detect Select gestures
        recogniser = new GestureRecognizer();
        recogniser.Tapped += (args) =>
        {
            // Send an OnSelect message to the focused object
            if(FocusedObject != null)
            {
                FocusedObject.SendMessageUpwards("OnSelect", SendMessageOptions.DontRequireReceiver);
            }
        };
        recogniser.StartCapturingGestures();
    }
	
	// Update is called once per frame
	void Update () {
        // Figure out which hologram we are seeing
        GameObject oldFocusedObject = FocusedObject;

        // Raycast to discover hologram
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;


        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition,gazeDirection, out hitInfo))
        {
            // Use the new hologram as focused object
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            // Clear the focused object
            FocusedObject = null;
        }

        // Start a new gesture detection if the focused object has changed
        if (FocusedObject!=oldFocusedObject)
        {
            recogniser.CancelGestures();
            recogniser.StartCapturingGestures();
        }
	}
}
