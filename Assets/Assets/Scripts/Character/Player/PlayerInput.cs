﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class PlayerInput : MonoBehaviour {

	public Player _player;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Init ();
		Attack ();
		getOptionalKeys ();
		//Move ();
		//Avoid ();

	}

	public void Init() {
		_player.mAnim.SetBool ("Left", false);
		_player.mAnim.SetBool ("Right", false);
	}
	/*
	public void Move(){

		float moveFB = Input.GetAxis ("Horizontal");
		float moveLR = Input.GetAxis ("Vertical");

		_player.mAnim.SetFloat ("moveFB", moveLR);
		_player.mAnim.SetFloat ("moveLR", moveFB);

	}
	*/
	public void getOptionalKeys (){
        if (Input.GetKey(KeyCode.P)) {
			if( Time.timeScale == 0 )
				Time.timeScale = 1f;
			else
				Time.timeScale = 0f;
		}
	}

	public void Attack(){

		// 왼팔 
		if (Punch_Judgment.attackMode.CompareTo ("Hook_L") == 0) {
			_player.mAnim.SetInteger ("AttackMode", 1);
			_player.mAnim.SetBool ("Left", true);
			_player.mAnim.SetBool ("Right", false);
			SoundManager.instance.AttackWindSound ();
			//InputTracking.Recenter ();

		} else if (Punch_Judgment.attackMode.CompareTo ("Jap_L")== 0) {
			_player.mAnim.SetInteger ("AttackMode", 2);
			_player.mAnim.SetBool ("Left", true);
			_player.mAnim.SetBool ("Right", false);
			SoundManager.instance.AttackWindSound ();
			//InputTracking.Recenter ();

		} else if (Punch_Judgment.attackMode.CompareTo ("Upper_L")== 0) {
			_player.mAnim.SetInteger ("AttackMode", 2);
			_player.mAnim.SetBool ("Left", true);
			_player.mAnim.SetBool ("Right", false);
			SoundManager.instance.AttackWindSound ();
			//InputTracking.Recenter ();
		}

		// 오른팔 
		if (Punch_Judgment.attackMode.CompareTo ("Hook_R")== 0) {
			_player.mAnim.SetInteger ("AttackMode", 1);
			_player.mAnim.SetBool ("Left", false);
			_player.mAnim.SetBool ("Right", true);
			SoundManager.instance.AttackWindSound ();
			//InputTracking.Recenter ();

		} else if (Punch_Judgment.attackMode.CompareTo ("Jap_R")== 0) {
			_player.mAnim.SetInteger ("AttackMode", 2);
			_player.mAnim.SetBool ("Left", false);
			_player.mAnim.SetBool ("Right", true);
			SoundManager.instance.AttackWindSound ();
			//InputTracking.Recenter ();

		} else if (Punch_Judgment.attackMode.CompareTo ("Upper_R")== 0) {
			_player.mAnim.SetInteger ("AttackMode", 2);
			_player.mAnim.SetBool ("Left", false);
			_player.mAnim.SetBool ("Right", true);
			SoundManager.instance.AttackWindSound ();
			InputTracking.Recenter ();
		}
	}
	/*
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


	}*/

}
