using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextSceneText : MonoBehaviour {
	string talking ="YOU WIN!sfdgfchgjhghjhbknjlmkfhgbhjjkngshadvjsahvdhasv";
	int i = 0;//i=length, type finish
	// Use this for initialization
	void Start () {
		InvokeRepeating ("talkingText", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void talkingText()
	{
		if (i < talking.Length) {
			this.GetComponent<TextMesh> ().text = this.GetComponent<TextMesh> ().text + talking [i];
			i++;
		} else
			CancelInvoke ();
	}
}
