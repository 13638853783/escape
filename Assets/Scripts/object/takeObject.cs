using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeObject : MonoBehaviour {
	GameObject parentObject;
	Vector3 objectPosition;
	Vector3 parentPosition;
	bool gateIsOpen = false;
	// Use this for initialization
	void Start () {
		parentObject = GameObject.Find("DefaultAvatar");
		objectPosition = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		parentPosition = parentObject.transform.position;
		if ((parentPosition.x < objectPosition.x + 2) && (parentPosition.x > objectPosition.x - 2)
		   && (parentPosition.y < objectPosition.y + 2) && (parentPosition.y > objectPosition.y - 2)) 
		{
			if (Input.GetKeyUp (KeyCode.C)&&this.tag == "object") {
				this.transform.parent = parentObject.transform;
				this.transform.localPosition = new Vector3 (0, 3f, 0);
			}
			if (Input.GetKeyUp (KeyCode.F)&&this.tag == "gate" && !gateIsOpen ) {
				this.transform.parent.gameObject.transform.Rotate(0,90f, 0, Space.Self);
				gateIsOpen = true;
			}
			else if(Input.GetKeyUp (KeyCode.F)&&this.tag == "gate" && gateIsOpen ) {
				this.transform.parent.gameObject.transform.Rotate(0,-90f, 0, Space.Self);
				gateIsOpen = false;
			}
		}
	}
}
