using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour {

    public float BallInitialVelocity = 600f;
    private Rigidbody rd;
    private bool ballInPlay;
	void Awake () {
        rd = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rd.isKinematic = false;
            rd.AddForce(new Vector3(BallInitialVelocity, BallInitialVelocity, 0));
        }
		
	}
}
