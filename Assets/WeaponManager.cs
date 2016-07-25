using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WeaponManager : MonoBehaviour {
	MovementV2 mov;
	public List<Weapon> Weapons;
	IKController ikController;
	// Use this for initialization
	void Start () {
		mov = GetComponent<MovementV2> ();
		ikController = GetComponentInChildren<IKController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.Alpha1)){
			Weapons [0].SetAsWeapon (ikController);
			mov.armed = true;
		}
		if(Input.GetKey (KeyCode.Alpha2)){
			Weapons [1].SetAsWeapon (ikController);
			mov.armed = true;
		}
	}

}
