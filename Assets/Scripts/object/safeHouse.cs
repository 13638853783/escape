using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class safeHouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other) {
		// 销毁当前游戏物体
		if (other.collider.tag == "Player" && this.tag == "safeHouse0")
		{
			SceneManager.LoadScene("2");
		}
		if (other.collider.tag == "Player" && this.tag == "safeHouse1")
		{
			SceneManager.LoadScene("1");
		}
	}
}
