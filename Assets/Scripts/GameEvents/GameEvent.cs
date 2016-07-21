using UnityEngine;
using System.Collections;

public class GameEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(){
		Debug.Log("Hello");
		Vector3 c = new Vector3(1f,0f,0f);
		GetComponent<NetworkView>().RPC("TheEvent",RPCMode.AllBuffered,c);
	}
	[RPC]
	void TheEvent(Color color){
		GetComponent<Renderer>().material.color = color;
	}
}
