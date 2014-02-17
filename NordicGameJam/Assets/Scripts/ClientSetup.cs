using UnityEngine;
using System.Collections;

public class ClientSetup : Photon.MonoBehaviour {

	TextMesh text;

	bool connected = false;
	public GameObject networkObject;

	string gameName = "gameTest";

	void Awake() {
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Client");

		text = GameObject.Find ("ClientInfoText").GetComponent<TextMesh> ();

		//DontDestroyOnLoad (gameObject);

		PhotonNetwork.autoJoinLobby = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!connected) {
			PhotonNetwork.ConnectUsingSettings("1");
			connected = true;
		}
	}

	public void OnConnectedToMaster() {
		Debug.Log("Connected to Photon master, joining game "+gameName);
		PhotonNetwork.JoinRoom(gameName);
	}

	public void OnJoinedRoom()
	{
		Debug.Log ("Connected to server");
		
		//InstantiateNetworkObjectAndAdvance();
	}

	public void OnFailedToConnectToPhoton(DisconnectCause cause)
	{
		Debug.LogError("Cause: " + cause);
	}

	public void OnPhotonJoinRoomFailed() {
		Application.LoadLevel (Application.loadedLevel);
	}

	public void SetGameName(string name) {
		gameName = name;
	}
}
