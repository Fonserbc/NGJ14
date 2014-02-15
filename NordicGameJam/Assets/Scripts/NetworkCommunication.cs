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

	private PhotonView photonView;

	NeoLogicController neo;
	MorpheosLogicController morph;

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
		if (EveryoneReady()) {
			funcToCall(paramToCall);
		}
	}


	public void AdvanceLevel() {
		photonView.RPC("StartLevel", PhotonTargets.All, Application.loadedLevel + 1);
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

	[RPC]
	void HeReady() {
		heReady = true;
	}

	public void ImReady() {
		imReady = false;

		photonView.RPC ("HeReady", PhotonTargets.Others);
	}

	public bool EveryoneReady() {
		if (imReady && heReady) {
			imReady = false; heReady = false;

			return true;
		}
		return false;
	}

	// Information senders

	public void ActivateButton (int id) {
		photonView.RPC ("ActivateButtonRPC", PhotonTargets.All, id);
	}

	[RPC]
	void ActivateButtonRPC (int id) {
		if (id == 0) leftButton.SwitchColor ();
		else rightButton.SwitchColor ();
	}

	public void SendNeoPosition (Vector3 pos) {
		photonView.RPC ("SendNeoPositionRPC", PhotonTargets.Others, pos);
	}

	[RPC]
	void SendNeoPositionRPC (Vector3 pos) {
		if (!PhotonNetwork.isMasterClient) {
			morph.SetNeoPosition(pos);
		}
	}
}
