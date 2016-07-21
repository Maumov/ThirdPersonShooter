using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {
	public string Version = "v0.1";
	public bool OfflineMode;
	bool connecting = false;
	SpawnSpot[] spots;
	List<string> chatMessages;
	int maxChatMessages = 5;
	// Use this for initialization
	void Start () {
		spots = GameObject.FindObjectsOfType<SpawnSpot>();
		PhotonNetwork.player.name = PlayerPrefs.GetString("Username","Player Name");
		chatMessages = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AddChatMessage(string m){
		GetComponent<PhotonView>().RPC("AddChatMessage_RPC",PhotonTargets.All,m);
	}
	[RPC]
	void AddChatMessage_RPC(string m){
		chatMessages.Add(m);
		while(chatMessages.Count>=maxChatMessages){
			chatMessages.RemoveAt(0);
		}
	}

	void OnDestroy(){
		PlayerPrefs.SetString("Username",PhotonNetwork.player.name);
		//custom properties, look it up in PhotonNetwork thing.
//		Hashtable props = PhotonNetwork.player.customProperties;
//		props["ASDASDA"] = 2;
//		PhotonNetwork.player.SetCustomProperties(props);
	}
	void Connect(){
	
		PhotonNetwork.ConnectUsingSettings(Version);

	
	}
	void OnGUI(){
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		if(PhotonNetwork.connected == false && connecting == false){
			GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();

			GUILayout.BeginHorizontal();
			GUILayout.Label("Username: ");
			PhotonNetwork.player.name = GUILayout.TextField(PhotonNetwork.player.name);
			GUILayout.EndHorizontal();

			GUILayout.FlexibleSpace();
			if(GUILayout.Button("Single Player")){
				connecting = true;
				PhotonNetwork.offlineMode = true;
				OnJoinedLobby();
			}
			if(GUILayout.Button("MultiPlayer Player")){
				connecting = true;
				Connect();
			}		
			GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();

		}
		if(PhotonNetwork.connected == true && connecting == false){
			//chat box
			GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();
			foreach(string msg in chatMessages){
				GUILayout.Label(msg);
			}

			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
	}
	void OnJoinedLobby(){
		Debug.Log("JoinedLobby");
		PhotonNetwork.JoinRandomRoom();
	}
	void OnPhotonRandomJoinFailed(){
		Debug.Log("Error Joining Random Room");
		PhotonNetwork.CreateRoom(null);
	}
	void OnJoinedRoom(){
		Debug.Log("JoinedRoom");
		connecting = false;
		SpawnMyPlayer();
	}
	void SpawnMyPlayer(){
		AddChatMessage("Spawning player:" + PhotonNetwork.player.name);
		if(spots == null){
			Debug.LogError("NO SPAWN POINTS ON THE MAP ! ! !");
			return; 
		}else{
			SpawnSpot mySpawnSpot = spots[Random.Range(0,spots.Length)];
			GameObject MyPlayerGO = (GameObject)PhotonNetwork.Instantiate("Player",mySpawnSpot.transform.position,mySpawnSpot.transform.rotation,0);
			MyPlayerGO.GetComponent<Movement>().enabled = true;
			MyPlayerGO.GetComponent<Shooting>().enabled = true;
			MyPlayerGO.transform.FindChild("Player Camera").gameObject.SetActive(true);
			MyPlayerGO.GetComponentInChildren<AnimationsEventHandler>().isMine = true;
			MyPlayerGO.GetComponent<CharacterController>().enabled = true;
		}

	}
}
