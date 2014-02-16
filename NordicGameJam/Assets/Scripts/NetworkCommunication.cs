using UnityEngine;
using System.Collections;
using System;

public class NetworkCommunication : MonoBehaviour {

	private bool imReady = false;
	private bool heReady = false;

	//private Action<int> funcToCall;
	//private int paramToCall;

	private PhotonView photonView;

	NeoLogicController neo;
	MorpheosLogicController morph;

	GameObject gameOverText;

	void OnLevelWasLoaded() {
		neo = GameObject.Find ("Manager").GetComponent<NeoLogicController>();
		morph = GameObject.Find ("Manager").GetComponent<MorpheosLogicController>();
	}

	// Use this for initialization
	void Start () {
		photonView = gameObject.GetComponent<PhotonView> ();
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Networking fun stuff

	public void Lose() {
		photonView.RPC ("LoseRPC", PhotonTargets.All);
	}

	[RPC]
	void LoseRPC() {
		Camera.main.BroadcastMessage ("GameOver");
	}

	public void RestartLevel() {
		photonView.RPC ("StartLevel", PhotonTargets.All, Application.loadedLevel - ((PhotonNetwork.isMasterClient)? 0 : 1));
	}

	public void AdvanceLevel() {
		if (Application.loadedLevel == 0) photonView.RPC("StartLevel", PhotonTargets.All, 1);
		else photonView.RPC("StartLevel", PhotonTargets.All, Application.loadedLevel + ((PhotonNetwork.isMasterClient)? 2 : 1));
	}

	[RPC]
	void StartLevel (int i) {
		if (!PhotonNetwork.isMasterClient) {
			Debug.Log("StartingLevel "+(i+1)+", I'm client");

			Application.LoadLevel(i+1);
			/*ImReady();

			funcToCall = Application.LoadLevel;
			paramToCall = i;*/
		}
		else {
			Debug.Log("StartingLevel "+i+", I'm Server");

			Application.LoadLevel(i);
			/*ImReady();

			funcToCall = Application.LoadLevel;
			paramToCall = i;*/
		}
	}
	
	// Information senders

	public void SendNeoPosition (Vector3 pos) {
		photonView.RPC ("SendNeoPositionRPC", PhotonTargets.Others, pos);
	}

	[RPC]
	void SendNeoPositionRPC (Vector3 pos) {
		if (!PhotonNetwork.isMasterClient) {
			morph.SetNeoPosition(pos);
		}
	}

	public void SendObjectActive (string parent, string name, int active) {
		photonView.RPC ("SendObjectActiveRPC", PhotonTargets.All, parent, name, active);

		morph.ObjectPressed ();
	}

	[RPC]
	void SendObjectActiveRPC (string parent, string name, int active) {
		GameObject.Find (parent).transform.FindChild (name).BroadcastMessage ("SetActive", active);
	}
}
