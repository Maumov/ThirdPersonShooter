using UnityEngine;
using System.Collections;

public class IKController : MonoBehaviour {
	public GameObject RightHand;
	public GameObject LeftHand;
	public bool PositionLeftHand,PositionRightHand,RotationLeftHand,RotationRightHand;
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
		if(PositionLeftHand){
			anim.SetIKPosition(AvatarIKGoal.LeftHand, LeftHand.transform.position);
		}
		if(RotationLeftHand){
			anim.SetIKRotation(AvatarIKGoal.LeftHand, LeftHand.transform.rotation);

		}

		anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
		anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
		if(PositionRightHand){
			anim.SetIKPosition(AvatarIKGoal.RightHand, RightHand.transform.position);
		}
		if(RotationRightHand){
			anim.SetIKRotation(AvatarIKGoal.RightHand, RightHand.transform.rotation);
		}
	}
}
