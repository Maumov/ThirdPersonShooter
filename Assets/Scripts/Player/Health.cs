using UnityEngine;
using System.Collections;

public class Health : Photon.MonoBehaviour {
	public float Hitpoints = 100f;
	public float currentHitPoints;
	public Animator anim;
	// Use this for initialization
	void Start () {
		currentHitPoints = Hitpoints;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void TakeDamage(float amount){
		//Damage(amount);
		GetComponent<PhotonView>().RPC("Damage",PhotonTargets.All,amount);
	}
	[RPC]
	public void Damage(float amount){
		anim.SetBool("Resurrected",false);
		currentHitPoints -= amount;
		if(currentHitPoints <=0){
			Die();
		}
	}

	void Die(){
		anim.SetTrigger("Dead");
		GetComponent<CapsuleCollider>().enabled=false;
		GetComponent<CharacterController>().enabled=false;
		GetComponentInChildren<IKController>().enabled=false;
		GetComponent<Movement>().enabled=false;
		GetComponent<Shooting>().enabled=false;
		Invoke("Respawn",5f);
	}
	void Respawn(){
		GetComponent<NetworkCharacter>().Respawn();
		currentHitPoints = Hitpoints;
	}
	public float getHealth(){
		return currentHitPoints;
	}
	public void setHealth(float value){
		currentHitPoints = value;
	}
}
