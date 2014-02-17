using UnityEngine;
using System.Collections;

public class EnterCamLight : MonoBehaviour {

	NetworkCommunication net;

	public bool activeCam;

	void Start() {
		net = GameObject.FindGameObjectWithTag ("NetworkObject").GetComponent<NetworkCommunication> ();
		activeCam = true;
	}

	void Update() {
		if (!PhotonNetwork.isMasterClient) 
			renderer.material.color = (activeCam)? Color.white : Color.black; //////////////////////
	}


	public void LooseIfActive() {
		if (activeCam) net.Lose ();
	}

	public void SetActive(int i) {
		activeCam = (i == 1);
	}

	void Activate(bool b) {
		net.SendObjectActive (transform.parent.name, gameObject.name, (activeCam)? 0 : 1);
	}
}
