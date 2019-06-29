using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peopleStart : MonoBehaviour {
	private Animator animator;
	bool isRun;
	// Use this for initialization
	void Start () {
		isRun = false;
		animator = GetComponent<Animator> ();
		int state = Random.Range(0,2);
		GetComponent<Rigidbody> ().AddForce (new Vector3 (0f,98f,0f));
		this.transform.position = new Vector3 (transform.position.x, 1.5f, transform.position.z);
		switch (state) 
		{
		case 0:
			animator.SetTrigger ("toSquat");
			break;
		case 1:
			animator.SetTrigger ("toRun");
			isRun = true;
			InvokeRepeating ("getDirection", 0f, 3f);
			break;
		default:
			animator.SetTrigger ("toRun");
			isRun = true;
			InvokeRepeating ("getDirection", 0f, 3f);
			break;
		}
	}
	void getDirection()
	{
		transform.Rotate(0, Random.Range(0,360), 0, Space.Self);
	}
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x < -25f || this.transform.position.x > 25f
		    || this.transform.position.z < -25f || this.transform.position.z > 25f) {
			InvokeRepeating ("getDirection", 0f, 0.2f);
		}
	}
}
