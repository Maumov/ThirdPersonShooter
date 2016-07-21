using UnityEngine;
using System.Collections;

public class NetworkBullet : Photon.MonoBehaviour {
	public float Speed;
	Vector3 realPosition;
	Quaternion realRotation;
	public float refreshRate = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(photonView.isMine){
			transform.position += transform.forward*(Speed*Time.deltaTime); 
		}else{
			transform.position = Vector3.Lerp(transform.position, realPosition,refreshRate);
			transform.rotation = Quaternion.Lerp(transform.rotation,  realRotation ,refreshRate);
		}

	}
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if(stream.isWriting ){
			//this is our Player. (sends out the info to the network)
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);

		}else{

			//receive somone else is info to update on his player
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();

		}
	}
}
