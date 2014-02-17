using UnityEngine;
using System.Collections;

public class ServerSetup : Photon.MonoBehaviour {

	public GameObject networkObject;

	private bool canConnect = false;
	private bool needsAdvance = false;

	private string gameName = "gameTest";

	private NetworkCommunication network;

	// Use this for initialization
	void Start () {
		Debug.Log ("Server");

		//DontDestroyOnLoad (gameObject);

		PhotonNetwork.autoJoinLobby = false;
		PhotonNetwork.ConnectUsingSettings("1");
	}
	
	// Update is called once per frame
	void Update () {
		if (canConnect) {
			if (PhotonNetwork.playerList.Length > 1)
				InstantiateNetworkObjectAndAdvance();
		}
		if (needsAdvance) network.AdvanceLevel ();
	}

	void OnConnectedToMaster () {
		Debug.Log ("Connected to Photon master, creating room "+gameName);
		PhotonNetwork.CreateRoom(gameName, true, true, 2);
	}

	void OnServerInitialized() {
		Debug.Log("Server initialized and ready");
	}

	public void OnJoinedRoom()
	{
		Debug.Log ("Connected to server, on room "+gameName);
		canConnect = true;
	}

	public void OnFailedToConnectToPhoton(DisconnectCause cause) {
		Debug.LogError("Cause: " + cause);
	}
	
	void InstantiateNetworkObjectAndAdvance() {
		network = ((GameObject) PhotonNetwork.InstantiateSceneObject ("NetworkObject", new Vector3(), new Quaternion(), 0, null)).GetComponent<NetworkCommunication>();
		needsAdvance = true;
		canConnect = false;
	}

	public void SetGameName(string name) {
		gameName = name;
	}

	void OnPhotonCreateGameFailed() {
		Application.LoadLevel (Application.loadedLevel);
	}
}
