﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class startButton : MonoBehaviour {
	// Use this for initialization
	void Start () {
		this.GetComponent<Button>().onClick.AddListener(loadScene);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void loadScene(){
		SceneManager.LoadScene("0");
	}
}
