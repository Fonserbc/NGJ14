using UnityEngine;
using System.Collections;

public class ServerSetup : MonoBehaviour {

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
		Network.InitializeServer (1, 42424, !Network.HavePublicAddress ());
		MasterServer.RegisterHost ("MorphneoGame", "NeoGame");
	}
}
