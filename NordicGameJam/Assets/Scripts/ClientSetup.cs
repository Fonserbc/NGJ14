using UnityEngine;
using System.Collections;

public class ClientSetup : Photon.MonoBehaviour {

	TextMesh text;

	bool connected = false;
	public GameObject networkObject;

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
		Debug.Log("Connected to Photon master");
		PhotonNetwork.JoinRandomRoom();
	}

	void InstantiateNetworkObjectAndAdvance() {
		NetworkCommunication network = ((GameObject) PhotonNetwork.InstantiateSceneObject ("NetworkObject", new Vector3(), new Quaternion(), 0, null)).GetComponent<NetworkCommunication>();
		network.AdvanceLevel ();
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
}
