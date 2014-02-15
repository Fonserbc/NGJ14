using UnityEngine;
using System.Collections;

public class ClientSetup : MonoBehaviour {

	TextMesh text;

	void Awake() {
		MasterServer.RequestHostList ("MorphneoGame");
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Client");

		text = GameObject.FindGameObjectWithTag ("clientInfo").GetComponent<TextMesh> ();

		DontDestroyOnLoad (gameObject);

		//SetUpClient ();
	}
	
	// Update is called once per frame
	void Update () {
		HostData[] hosts = MasterServer.PollHostList ();

		text.text = "Hosts: "+hosts.Length;
	}

	void SetUpClient() {

	}


}
