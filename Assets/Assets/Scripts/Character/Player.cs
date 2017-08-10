﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters<Enermy>
{
	// 움직임 변수
	public float mouseSensitivity = 2f;
	public float upDownRange= 30;

	private float rotationX;
	private float rotationY;

	public Vector3 mDir;
	public Camera mCamera;


	// 델리게이트 
	public delegate void PlayerAttackHandler();
	public static event PlayerAttackHandler OnPlayerAttack;

	Player(){}

	public override void Start(){
		mCamera = GetComponentInChildren<Camera> ();
		mAnim.SetInteger ("AttackMode", 1);

		Cursor.lockState = CursorLockMode.Locked;

	}

	void FixedUpdate () 
	{ 
		Init ();
		Move ();
		Attack ();
	} 

	public override void applyDamage(){
		Player.OnPlayerAttack ();
		print (this.name +" applied damage : " + this.Damage);
	}

	public override void getDamage(){ }

	void OnTriggerEnter( Collider col ){

		if ( col.transform.tag == "HandCol" ){
			mAnim.SetBool ("Damaged", true);
			//print (this.name +" get damaged : " + Player.Damage);
			//Player.OnPlayerAttack ();
			//col.transform.SendMessage ("applyDamage", Player.playerDamage);
		}

	}

	public override void Move(){

		mDir = new Vector3 ( mAnim.GetFloat("moveLR"), 0, mAnim.GetFloat("moveFB") );
		transform.Translate ( mDir * Time.smoothDeltaTime * moveSpeed );
	}

	public override void Attack(){

		int _AttackMode = mAnim.GetInteger ("AttackMode");
		bool _AttackLeft = mAnim.GetBool ("Left");
		bool _AttackRight = mAnim.GetBool ("Right");

		switch (_AttackMode) {

		case 1:
			Damage = hookDamage;
			break;
		case 2:
			Damage = japDamage;
			break;
		case 3:
			Damage = upperDamage;
			break;
		case 4:
			Damage = comboDamage;
			break;

		}

		if( _AttackLeft == true )
			mHand_L.enabled = true;
		else
			mHand_L.enabled = false;

		if( _AttackRight == true )
			mHand_R.enabled = true;
		else
			mHand_R.enabled = false;

	}
}