﻿using UnityEngine;
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
		photonView.RPC("StartLevel", PhotonTargets.All, 2);
	}

	void OnPhotonPlayerDisconnected(PhotonPlayer player) {
		Application.Quit ();
	}

	[RPC]
	void StartLevel (int i) {
		if (!PhotonNetwork.isMasterClient) {
			Debug.Log("StartingLevel "+(i+1)+", I'm client");

			Application.LoadLevel(i+1);

			Debug.Log("Level "+(i+1)+" loaded");
			/*ImReady();

			funcToCall = Application.LoadLevel;
			paramToCall = i;*/
		}
		else {
			Debug.Log("StartingLevel "+i+", I'm Server");

			Application.LoadLevel(i);

			Debug.Log("Level "+(i)+" loaded");
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
			GameObject.Find("Neo").SendMessage("Beep");
		}
	}

	public void SendObjectActive (string parent, string name, int active) {
		photonView.RPC ("SendObjectActiveRPC", PhotonTargets.All, parent, name, active);

		if (morph != null) morph.ObjectPressed ();
	}

	[RPC]
	void SendObjectActiveRPC (string parent, string name, int active) {
		GameObject.Find (parent).transform.FindChild (name).SendMessage ("SetActive", active);
	}

	public void SendEnergy() {
		photonView.RPC ("SendEnergyRPC", PhotonTargets.Others);
	}

	[RPC]
	void SendEnergyRPC() {
		morph.RegainPower();
	}

	public void TurnLights (string name) {
		photonView.RPC ("TurnLightsRPC", PhotonTargets.MasterClient, name);
	}

	[RPC]
	void TurnLightsRPC (string name) {
		GameObject.Find ("Manager").SendMessage ("setLight", name);
	}
}
