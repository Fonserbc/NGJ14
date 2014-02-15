using UnityEngine;
using System.Collections;
using System;

public class NetworkCommunication : MonoBehaviour {

	private bool imReady = false;
	private bool heReady = false;

	private ButtonSyncTest rightButton;
	private ButtonSyncTest leftButton;

	private Action<int> funcToCall;
	private int paramToCall;

	void OnLevelWasLoaded() {
		rightButton = GameObject.Find ("ButtonRight").GetComponent<ButtonSyncTest>();
		leftButton = GameObject.Find ("ButtonLeft").GetComponent<ButtonSyncTest>();
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (EveryoneReady()) {
			funcToCall(paramToCall);
		}
	}

	public void AdvanceLevel() {
		StartLevel (Application.loadedLevel + 1);
	}

	[RPC]
	void StartLevel (int i) {
		if (Network.isClient) {
			Debug.Log("StartingLevel "+i+", I'm client");

			ImReady();

			funcToCall = Application.LoadLevel;
			paramToCall = i;
		}
		else if (Network.isServer) {
			Debug.Log("StartingLevel "+i+", I'm Server");
			
			ImReady();

			funcToCall = Application.LoadLevel;
			paramToCall = i;
		}
		else {
			Debug.Log("Error no network initialized!");
		}
	}

	[RPC]
	void HeReady() {
		heReady = true;
	}

	public void ImReady() {
		imReady = false;

		networkView.RPC ("HeReady", RPCMode.Others);
	}

	public bool EveryoneReady() {
		if (imReady && heReady) {
			imReady = false; heReady = false;

			return true;
		}
		return false;
	}

	public void ActivateButton (int id) {
		networkView.RPC ("ActivateButtonRPC", RPCMode.All, id);
	}

	[RPC]
	void ActivateButtonRPC (int id) {
		if (id == 0) leftButton.SwitchColor ();
		else rightButton.SwitchColor ();
	}
}
