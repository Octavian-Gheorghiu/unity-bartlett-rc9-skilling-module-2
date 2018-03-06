using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// STEP 1: Add a reference to the HoloToolkit
using HoloToolkit.Unity.InputModule;
using System;

// STEP 2: Our script will implement functionality from the IInputClickHandler and ISpeechHandler
public class CubeManager : MonoBehaviour, IInputClickHandler, ISpeechHandler
{
    // Variables
    Vector3 cubeScale;
    float minScale = 0.3f;
    float maxScale = 0.5f;
    float currentScale;

	// Use this for initialization
	void Start () {
        cubeScale = new Vector3(minScale, minScale, minScale);
        transform.localScale = cubeScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			GetComponent<Animator> ().SetBool ("SpinCube", true);
		} else {
			GetComponent<Animator> ().SetBool ("SpinCube", false);
		}
	}

    // Custom code for gaze detection
    public void SpinCube()
    {
        GetComponent<Animator>().SetBool("SpinCube", true);
    }
    public void StopSpinCube()
    {
        GetComponent<Animator>().SetBool("SpinCube", false);
    }

    // STEP 3: Write the custom code for extending the IInputHandler
    // Custom code for input detection
    public void OnInputClicked(InputClickedEventData eventData)
    {
        // AirTap code goes here

        // Ask the cube if it is spinning
        if(GetComponent<Animator>().GetBool("SpinCube") == false)
        {
            // If it is not spinning start spinning the cube
            GetComponent<Animator>().SetBool("SpinCube", true);
        } else
        {
            // If it is spinning stop spinning the cube
            GetComponent<Animator>().SetBool("SpinCube", false);
        }

        // Homework:
        // Move the cube to the left 
        
    }
    public void OnInputDown(InputEventData eventData)
    {
        // Holding the AirTap code goes here

        // Make the cube scale up and then down
        currentScale = transform.localScale.x;
        if(currentScale < maxScale)
        {
            currentScale += 0.05f;
            cubeScale = new Vector3(currentScale, currentScale, currentScale);
        } else
        {
            currentScale = minScale;
            cubeScale = new Vector3(currentScale, currentScale, currentScale);
        }

    }
    public void OnInputUp(InputEventData eventData)
    {
        // Releasing the AirTap code goes here
    }

    // STEP 4 : CUSTOM CODE FOR SPEECH RECOGNITION
    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        // Your code goes here

        // If we recognize the keyword spin
        if (eventData.RecognizedText == "Spin")
        {
            // We start spinning the cube
            GetComponent<Animator>().SetBool("SpinCube", true);
        }
        // If we recognize the keyword stop
        if(eventData.RecognizedText == "Stop")
        {
            // We stop spinning the cube
            GetComponent<Animator>().SetBool("SpinCube", false);
        }

        // Homework: 
        // If we recognize the keyword Architecture
        // We get the MeshRender component and get the material component
        // We set the material color to a new color
    }
}
