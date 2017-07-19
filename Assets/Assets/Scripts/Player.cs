﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// 움직임 변수
	public float moveSpeed = 5f;
	public float mouseSensitivity = 2f;
	public float upDownRange= 30;

	private float rotationX;
	private float rotationY;
	private Rigidbody mRigidbody;

	public static float Power = 1;
	public static float HP = 100;
	public float hookDamage = 10;
	public float japDamage = 5;
	public float upperDamage = 15;
	public float comboDamage = 35;

	Vector3 mDir;
	Transform target;

	public Animator mAnim; 	// 애니메이션
	public Camera mCamera;

	// 델리게이트 
	public delegate void PlayerAttackHandler();
	public static event PlayerAttackHandler OnPlayerAttack;

	void Start(){
		mRigidbody = GetComponent<Rigidbody> ();
		mAnim = GetComponentInChildren<Animator> ();
		mCamera = GetComponentInChildren<Camera> ();

		Cursor.lockState = CursorLockMode.Locked;
		target = GameObject.FindGameObjectWithTag ("Enermy").transform;

		mAnim.SetInteger ("AttackMode", 1);
		//StartCoroutine ("applyDamage");
	}

	void FixedUpdate () 
	{ 
		init();
		Move ();
		Attack ();;
	} 

	void init() {
		mAnim.SetBool ("Left", false);
		mAnim.SetBool ("Right", false);
		mAnim.SetBool ("Damaged", false);
	}

	public void applyDamage(float damage){
		Player.OnPlayerAttack ();
		print (this.name +" applied damage : " + Player.Power);
	}

	public void getDamage(float damage){
	}

	void OnTriggerEnter( Collider col ){

		if ( col.transform.tag == "HandCol" ){
			mAnim.SetBool ("Damaged", true);
			//print (this.name +" get damaged : " + Player.Power);
			//Player.OnPlayerAttack ();
			//col.transform.SendMessage ("applyDamage", Player.playerPower);
		}

	}

	void Attack(){
		// 어택 모드 설정
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			mAnim.SetInteger ("AttackMode", 1);
			Power = hookDamage;

		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			mAnim.SetInteger ("AttackMode", 2);
			Power = japDamage;

		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			mAnim.SetInteger ("AttackMode", 3);
			Power = upperDamage;

		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			mAnim.SetInteger ("AttackMode", 4);
			Power = comboDamage;
		}

		// 왼쪽, 오른쪽 공격 설정
		if (Input.GetMouseButton (0)) { 
			mAnim.SetBool ("Right", false);
			mAnim.SetBool ("Left", true);


		} else if (Input.GetMouseButton (1)) { 
			mAnim.SetBool ("Left", false);
			mAnim.SetBool ("Right", true);
		} 

	}

	void Move(){
		
		float moveFB = Input.GetAxis ("Horizontal");
		float moveLR = Input.GetAxis ("Vertical");

		mDir = new Vector3 (moveFB, 0, moveLR);
		mDir = mCamera.transform.TransformDirection (mDir);
		mRigidbody.AddForce (mDir * moveSpeed * Time.smoothDeltaTime, ForceMode.Force);
		mRigidbody.velocity = mDir * moveSpeed;

		mAnim.SetFloat ("moveFB", moveLR);
		mAnim.SetFloat ("moveLR", moveFB);

		//좌우 회전
		rotationX = Input.GetAxis ("Mouse X") * mouseSensitivity + transform.localEulerAngles.y;

		//상하 회전
		rotationY += Input.GetAxis ("Mouse Y") * mouseSensitivity;
		rotationY = Mathf.Clamp (rotationY, -upDownRange, upDownRange);

		transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0f);
	}

}