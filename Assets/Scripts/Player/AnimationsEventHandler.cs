using UnityEngine;
using System.Collections;

public class AnimationsEventHandler : MonoBehaviour {
	public Transform BulletSpawnPoint;
	public bool isMine;
	// Use this for initialization
	void Start () {
	
	}
	void SpawnBullet(){
		if(isMine){
			PhotonNetwork.Instantiate("ArrowPrefab",BulletSpawnPoint.position,transform.rotation,0);
		}
	}
}
