using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public float speed = 5.0f;Vector3 upward = new Vector3(0f,0f,1f);Vector3 downward = new Vector3(0f,0f,-1f);
	Vector3 leftward = new Vector3(-1f,0f,0f);
	bool isWalk = false,isRun = false,isBackWalk = false;
	//move

	//方向灵敏度
	public float sensitivityX = 6f;
	public float sensitivityY = 6f;

	//上下的最大视角
	public float minY = -60f;
	public float maxY = 60f;

	float rotationY = 0f;
	float rotationX = 0f;
	//jump
	bool m_isJumping = false;
	float m_jumpTime = 1;
	float ym;
	float m_gravity = 9.8f;
	float oldY;
	public bool delayJump = false;
	float delayJumpTime = 1f;
	//animation
	Animator animator;
	// Use this for initialization
	void Start () {
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		oldY = transform.position.y;

		if (rigidbody)
		{
			rigidbody.freezeRotation = true;
		}
	}

	// Update is called once per frame
	void Update () {
		//获取鼠标左右旋转的角度
		rotationX += Input.GetAxis("Mouse X") * sensitivityX;

		//获取鼠标上下旋转的角度
	//	rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

		//角度限制，如果rorationY小于min返回min，大于max返回max
		//rotationY = Clam(rotationY, minY, maxY);

		//设置摄像机的角度
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		/*because of the animator, this part is useless. 
		*/ if (Input.GetKeyDown(KeyCode.W)) {
			isWalk = true;
			//transform.Translate(upward * Time.deltaTime * speed);
			//animator.speed = 1f;
			//GameObject.Find ("Main Camera").transform.Translate(Vector3.up * Time.deltaTime * speed);
		}
		if (Input.GetKeyUp(KeyCode.W)) {
			isWalk = false;
		}
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			isRun = true;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			isRun = false;
		}
		if (Input.GetKey(KeyCode.S)) {
			transform.Translate(downward * Time.deltaTime * speed);
			//GameObject.Find ("Main Camera").transform.Translate(Vector3.down * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.A)) {
			transform.Translate(leftward * Time.deltaTime * speed);
			//GameObject.Find ("Main Camera").transform.Translate(Vector3.up * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.Translate(-leftward * Time.deltaTime * speed);
			//GameObject.Find ("Main Camera").transform.Translate(Vector3.down * Time.deltaTime * speed);
		} /* */
		this.GetComponent<Rigidbody> ().AddForce (0f, -5000f, 0f);

		if (isWalk) {
			transform.Translate(upward * Time.deltaTime * speed*0.5f);
		}
		if (isWalk&isRun) {
			transform.Translate(upward * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.Space) && m_isJumping == false )
		{
			m_isJumping = true;
			Invoke ("ResetDelayTime", delayJumpTime);
			oldY = this.transform.position.y;
		}
		if (m_isJumping == true && delayJump) 
		{
			this.GetComponent<Rigidbody> ().AddForce (0f, 3000f, 0f);
		}
		if (this.transform.position.y - oldY > 1.2f ) 
		{
			m_isJumping = false;
			delayJump = false;
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			this.GetComponent<Rigidbody> ().AddForce (0f, -6000f, 0f);
		} 
	}

	void FixedUpdate (){
		
	}

	public float Clam(float value, float min, float max)
	{
		if(value < min) { return min; }
		if (value > max) { return max; }
		return value;
	} 
	void ResetDelayTime()
	{
		delayJump = true;
	}
}
