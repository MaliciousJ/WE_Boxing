﻿using UnityEngine;
using System.Collections;

public class HandCol_E : MonoBehaviour {

	public Player opponent;
	public Enermy me;
	public BoxCollider mHand;

	void Awake () {
		mHand.enabled = false;
	}

	void OnTriggerEnter(Collider col)
	{
		//적과 부딪힐때만 충돌처리 일어나도록 처리
		if (col.tag == opponent.tag && opponent.isUnBeatTime == false) {
			opponent.mDelig._AttackHandler ();
			SoundManager.instance.AttackSound ();
		}

	}

}
