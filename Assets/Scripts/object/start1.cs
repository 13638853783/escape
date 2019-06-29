using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start1 : MonoBehaviour {
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			animator.SetTrigger ("toWalk");
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			animator.SetTrigger ("stopWalk");
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			animator.SetTrigger ("toRun");
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			animator.SetTrigger ("stopRun");
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			animator.SetTrigger ("toJump");
			Invoke ("jumpFinish", 4f);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			animator.SetTrigger ("runToJump");
			Invoke ("runJumpFinish", 1.5f);
			animator.SetTrigger ("squatFinish");
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			animator.SetTrigger ("toBack");
		}
		if (Input.GetKeyUp (KeyCode.S)) {
			animator.SetTrigger ("stopBack");
			animator.SetTrigger ("squatFinish");
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			animator.SetTrigger ("toSquat");
			Invoke ("squatFinish", 6f);
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			animator.SetTrigger ("toRoll");
		}
		if (Input.GetKeyUp (KeyCode.Z)) {
			animator.SetTrigger ("stopRoll");
		}
	}
	void jumpFinish()
	{
		animator.SetTrigger ("jumpFinish");
	}
	void runJumpFinish()
	{
		animator.SetTrigger ("runJumpFinish");
	}
	void squatFinish()
	{
		animator.SetTrigger ("squatFinish");
	}
}
