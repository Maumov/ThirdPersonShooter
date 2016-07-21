using UnityEngine;
using System.Collections;

public class IKController : MonoBehaviour {
	public GameObject RightHand;
	public GameObject LeftHand;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnAnimatorIK(int num){
		anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
		anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
		anim.SetIKPosition(AvatarIKGoal.LeftHand, LeftHand.transform.position);
		anim.SetIKRotation(AvatarIKGoal.LeftHand, LeftHand.transform.rotation);

		anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
		anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
		anim.SetIKPosition(AvatarIKGoal.RightHand, RightHand.transform.position);
		anim.SetIKRotation(AvatarIKGoal.RightHand, RightHand.transform.rotation);
	}
}
