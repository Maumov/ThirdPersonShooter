using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public GameObject RightHandPosition, LeftHandPosition;
	public bool UsesLeftHand,UsesRightHand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetAsWeapon(IKController ikcontrol){
		if(UsesLeftHand){
			ikcontrol.LeftHand.transform.parent = LeftHandPosition.transform;
			ikcontrol.LeftHand.transform.localPosition = Vector3.zero;
			ikcontrol.LeftHand.transform.rotation = Quaternion.identity;
		}
		if(UsesRightHand){
			ikcontrol.RightHand.transform.parent = RightHandPosition.transform;
			ikcontrol.RightHand.transform.localPosition = Vector3.zero;
			ikcontrol.RightHand.transform.rotation = Quaternion.identity;
		}
		transform.parent = GameObject.FindGameObjectWithTag ("Player").transform;
		transform.localPosition = Vector3.zero;

		transform.localRotation = Quaternion.identity;
		transform.Rotate (0f,0f,90f);
	}
}
