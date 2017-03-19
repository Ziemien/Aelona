using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public GameObject leftSide;
    public GameObject rightSide;

    public float speed = 0.25f;

    private float state = 0;

    private Quaternion initialStateRight;
    private Quaternion initialStateLeft;

	// Use this for initialization
	void Start ()
	{
	    initialStateLeft = leftSide.transform.localRotation;
	    initialStateRight = rightSide.transform.localRotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var deltaTime = Time.deltaTime;
	    state = Mathf.Min(deltaTime * speed + state, 1);

	    leftSide.transform.localRotation = Quaternion.Lerp(initialStateLeft, Quaternion.identity, state);
	    rightSide.transform.localRotation = Quaternion.Lerp(initialStateRight, Quaternion.identity, state);
	}
}
