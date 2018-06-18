using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour 
{
	public bool scrolling,paralax;

	public float backgroundSize;
	public float paralaxSpeed;

	//To keep track of the camera
	private Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;

	private void Start()
	{
		//Defining the camera transform, fetching the current camera and setting the layers
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;
		layers = new Transform[transform.childCount];
		for(int i = 0; i < transform.childCount; i++)
			layers[i] = transform.GetChild(i);

		leftIndex = 0;
		rightIndex = layers.Length-1;//needs to be set to the very last object in the layers array
	}
	private void Update()
	{
		if (paralax) 
		{
			float deltaX = cameraTransform.position.x - lastCameraX;
			transform.position += Vector3.right * (deltaX * paralaxSpeed);
		}

		lastCameraX = cameraTransform.position.x;

		if (scrolling) 
		{
			if (cameraTransform.position.x < (layers [leftIndex].transform.position.x + viewZone))
				ScrollLeft ();

			if (cameraTransform.position.x > (layers [rightIndex].transform.position.x - viewZone))
				ScrollRight ();
		}
	}

	/*
	these two private functions that will be called if we are going to far towards the left or right side
	this is checked in the update above
	*/
	private void ScrollLeft()
	{
		/*
		this will be overiden so I need to temporarily keep a pointer towards
		the last index
		*/
		int lastRight = rightIndex;

		/*
		below is where, if the player goes to far towards the left side the very right image (that currently
		cant be seen) will be taken and put on the left
		*/
		layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0) // checking the boundaries
			rightIndex = layers.Length-1;
	}

	/*
	The exact same applies to this funtion as the one above, however, it is for if the player moves to the
	right side instead
	*/
	private void ScrollRight()
	{
		int lastLeft = leftIndex;
		layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
		rightIndex = leftIndex;
		leftIndex++;
		if(leftIndex == layers.Length)
			leftIndex = 0;

	}
}
