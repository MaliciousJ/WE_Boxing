﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public Player _player;
	public ArduInput _LeftInput;
	public ArduInput _RightInput;
	public Vector3 first;
	public Vector3 second;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Init ();
		//Move ();
		Attack ();
		//Avoid ();
	}


	public void Init() {
		_player.mAnim.SetBool ("Left", false);
		_player.mAnim.SetBool ("Right", false);
		_player.mAnim.SetBool ("Damaged", false);
	}
	/*
	public void Move(){

		float moveFB = Input.GetAxis ("Horizontal");
		float moveLR = Input.GetAxis ("Vertical");

		_player.mAnim.SetFloat ("moveFB", moveLR);
		_player.mAnim.SetFloat ("moveLR", moveFB);

	}
	*/
	public int getGesture (){
		return 0;
	}

	public void Attack(){

		// 왼팔 
		if (Punch_Judgment.attackMode.CompareTo ("Hook_L") == 0) {
			_player.mAnim.SetInteger ("AttackMode", 1);
			_player.mAnim.SetBool ("Left", true);
			_player.mAnim.SetBool ("Right", false);
			_LeftInput.punch ();

		} else if (Punch_Judgment.attackMode.CompareTo ("Jap_L")== 0) {
			_player.mAnim.SetInteger ("AttackMode", 1);
			_player.mAnim.SetBool ("Left", true);
			_player.mAnim.SetBool ("Right", false);
			_LeftInput.shoot ();

		} else if (Punch_Judgment.attackMode.CompareTo ("Upper_L")== 0) {
			_player.mAnim.SetInteger ("AttackMode", 1);
			_player.mAnim.SetBool ("Left", true);
			_player.mAnim.SetBool ("Right", false);
		}

		// 오른팔 
		if (Punch_Judgment.attackMode.CompareTo ("Hook_R")== 0) {
			_player.mAnim.SetInteger ("AttackMode", 1);
			_player.mAnim.SetBool ("Left", false);
			_player.mAnim.SetBool ("Right", true);
			_RightInput.punch ();

		} else if (Punch_Judgment.attackMode.CompareTo ("Jap_R")== 0) {
			_player.mAnim.SetInteger ("AttackMode", 1);
			_player.mAnim.SetBool ("Left", false);
			_player.mAnim.SetBool ("Right", true);
			_RightInput.shoot ();

		} else if (Punch_Judgment.attackMode.CompareTo ("Upper_R")== 0) {
			_player.mAnim.SetInteger ("AttackMode", 1);
			_player.mAnim.SetBool ("Left", false);
			_player.mAnim.SetBool ("Right", true);
		}
		/*
		// 어택 모드 설정
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			_player.mAnim.SetInteger ("AttackMode", 1);

		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			_player.mAnim.SetInteger ("AttackMode", 2);

		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			_player.mAnim.SetInteger ("AttackMode", 3);

		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			_player.mAnim.SetInteger ("AttackMode", 4);
		}
		// 왼쪽 공격 설정
		if (Input.GetMouseButton (0)) { 
			_player.mAnim.SetBool ("Left", true);
			_player.mAnim.SetBool ("Right", false);

			_LeftInput.punch ();
			_RightInput.punch ();
		} 

		// 오른쪽 공격 설정 
		if (Input.GetMouseButton (1)) { 
			_player.mAnim.SetBool ("Left", false);
			_player.mAnim.SetBool ("Right", true);

			_LeftInput.shoot ();
			_RightInput.shoot ();
		}*/

	}

	public void Avoid(){

		if (Input.GetKey (KeyCode.Q)) {
			_player.mAnim.SetBool ("guard", true);

		} else if (Input.GetKey (KeyCode.E)) {
			_player.mAnim.SetBool ("dodge", true);


		} else if (Input.GetKey (KeyCode.R)) {
			_player.mAnim.SetBool ("weaving", true);

		} else if (Input.GetKey (KeyCode.T)){
			_player.mAnim.SetBool ("crouch", true);

		} else {
			_player.mAnim.SetBool ("guard", false);
			_player.mAnim.SetBool ("dodge", false);
			_player.mAnim.SetBool ("crouch", false);
			_player.mAnim.SetBool ("weaving", false);

		}

		if (Input.GetKey (KeyCode.Q | KeyCode.E | KeyCode.R)){
			_player.mAnim.SetBool ("Left", false);
			_player.mAnim.SetBool ("Right", false);
		} 


	}

}
