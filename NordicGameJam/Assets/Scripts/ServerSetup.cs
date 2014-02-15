using UnityEngine;
using System.Collections;

public class ServerSetup : MonoBehaviour {

	public GameObject networkObject;

	// Use this for initialization
	void Start () {
		Debug.Log ("Server");

		DontDestroyOnLoad (gameObject);

		SetUpServer ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SetUpServer() {
		Network.InitializeServer (1, 42424, true);
		MasterServer.RegisterHost ("MorphneoGame", "NeoGame");
	}

	void OnServerInitialized() {
		Debug.Log("Server initialized and ready");
	}

	void OnPlayerConnected(NetworkPlayer player) {
		Debug.Log("Player " + " connected from " + player.ipAddress);

		InstantiateNetworkObjectAndAdvance();
	}

	void InstantiateNetworkObjectAndAdvance() {
		NetworkCommunication network = ((GameObject) GameObject.Instantiate (networkObject, new Vector3(), new Quaternion())).GetComponent<NetworkCommunication>();
		network.AdvanceLevel ();
	}
}
