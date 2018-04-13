using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour {
	public GameObject[] attacks;
	public GameObject currentAttack;
	private int currentAttackNum = 0;

	// Use this for initialization
	void Start () {
		SetAttack (currentAttackNum);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("weapon_next")) {
			SelectNextWeapon ();
		} else if (Input.GetButtonDown ("weapon_prev")) {
			SelectPreviousWeapon ();
		} else if (Input.GetButtonDown ("Fire1")) {
			LaunchAttack ();
		}
	}

	void SelectNextWeapon() {
		int nextAttack = currentAttackNum + 1;

		if (attacks.Length - 1 > nextAttack) {
			SetAttack(nextAttack);
		} else {
			SetAttack(0);
		}
	}

	void SelectPreviousWeapon() {
		int prevAttack = currentAttackNum - 1;

		if (prevAttack > -1) {
			SetAttack(prevAttack);
		} else {
			SetAttack(attacks.Length - 1);
		}
	}
	
	void SetAttack (int attackNum) {
		currentAttackNum = attackNum;
		currentAttack = attacks [attackNum];
	}

	void LaunchAttack () {
		float spawnDistance = 10;
		Vector3 playerPos = transform.position;
		Vector3 playerDirection = transform.forward;
		Quaternion playerRotation = transform.rotation;
		Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

		spawnPos.y = spawnPos.y + 0.85f;

		Instantiate (currentAttack, spawnPos, playerRotation);
	}
}
