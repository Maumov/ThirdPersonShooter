using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {
	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;
	public Animator anim;
	public float refreshRate = 0.05f;
	float realVertical = 0f,realHorizontal = 0f,realShoot = 0f;
	bool firstUpdate = false;
	bool realDead,realRess;
	public Health h;
	SpawnSpot[] spots;
	// Use this for initialization
	void Start () {
		spots = GameObject.FindObjectsOfType<SpawnSpot>();
		anim = GetComponent<Movement>().anim;
	}
	
	// Update is called once per frame
	void Update () {
		if(photonView.isMine){

		}else{
			transform.position = Vector3.Lerp(transform.position, realPosition,refreshRate);
			transform.rotation = Quaternion.Lerp(transform.rotation,  realRotation ,refreshRate);
			anim.SetFloat("Vertical",Mathf.Lerp(anim.GetFloat("Vertical"),realVertical,refreshRate));
			anim.SetFloat("Horizontal",Mathf.Lerp(anim.GetFloat("Horizontal"),realHorizontal,refreshRate));
			anim.SetFloat("Shoot",realShoot);
			anim.SetBool("Dead",realDead);
			anim.SetBool("Resurrected",realRess);
		}

	}
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if(stream.isWriting ){
			//this is our Player. (sends out the info to the network)
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(anim.GetFloat("Vertical"));
			stream.SendNext(anim.GetFloat("Horizontal"));
			stream.SendNext(anim.GetFloat("Shoot"));
			stream.SendNext(anim.GetBool("Dead"));
			stream.SendNext(anim.GetBool("Resurrected"));
			stream.SendNext (h.getHealth());
		}else{
			if(!firstUpdate){
				transform.position = (Vector3)stream.ReceiveNext();
				transform.rotation = (Quaternion)stream.ReceiveNext();
				anim.SetFloat("Vertical",(float)stream.ReceiveNext());
				anim.SetFloat("Horizontal",(float)stream.ReceiveNext());
				anim.SetFloat("Shoot",(float)stream.ReceiveNext());
				anim.SetBool("Dead",(bool)stream.ReceiveNext());
				anim.SetBool("Resurrected",(bool)stream.ReceiveNext());
				h.setHealth((float)stream.ReceiveNext());
				firstUpdate = !firstUpdate;
			}else{
				//receive somone else is info to update on his player
				realPosition = (Vector3)stream.ReceiveNext();
				realRotation = (Quaternion)stream.ReceiveNext();
				realVertical = (float)stream.ReceiveNext();
				realHorizontal = (float)stream.ReceiveNext();
				realShoot = (float)stream.ReceiveNext();
				realDead = (bool)stream.ReceiveNext();
				realRess = (bool)stream.ReceiveNext();
				h.setHealth((float)stream.ReceiveNext());
			}

		}
	}
	public void Respawn(){
		GetComponentInChildren<IKController>().enabled=true;
		anim.SetTrigger("Resurrected");
		GetComponent<Health>().setHealth(h.Hitpoints);
		SpawnSpot mySpawnSpot = spots[Random.Range(0,spots.Length)];
		transform.position = mySpawnSpot.transform.position+Vector3.up;
		transform.rotation = mySpawnSpot.transform.rotation;
		anim.SetBool("Dead",false);
		if(photonView.isMine){
			GetComponent<CharacterController>().enabled=true;
			GetComponent<Movement>().enabled=true;
			GetComponent<Shooting>().enabled=true;
		}else{
			GetComponent<CapsuleCollider>().enabled=true;
		}
	}
}
