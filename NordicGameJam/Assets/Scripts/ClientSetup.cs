using UnityEngine;
using System.Collections;

public class ClientSetup : MonoBehaviour {

	TextMesh text;

	bool connected = false;
	public GameObject networkObject;

	void Awake() {
		MasterServer.RequestHostList ("MorphneoGame");
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Client");

		text = GameObject.Find ("ClientInfoText").GetComponent<TextMesh> ();

		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (!connected) {
			HostData[] hosts = MasterServer.PollHostList ();

			text.text = ((hosts.Length == 0) ? "No hosts found" : "Found host!");

			if (hosts.Length == 0) {
				MasterServer.RequestHostList ("MorphneoGame");
			} else {
				hosts[0].useNat = true;
				NetworkConnectionError err = Network.Connect (hosts [0]);
				Debug.Log(err);

				connected = true;
			}
		}
	}

	void InstantiateNetworkObjectAndAdvance() {
		NetworkCommunication network = ((GameObject) GameObject.Instantiate (networkObject, new Vector3(), new Quaternion())).GetComponent<NetworkCommunication>();
		network.AdvanceLevel ();
	}

	void OnConnectedToServer() {
		Debug.Log ("Connected to server");
		
		InstantiateNetworkObjectAndAdvance();
	}

	void OnFailedToConnect() {
		Debug.Log ("Failed to connect to server");
	}
}
