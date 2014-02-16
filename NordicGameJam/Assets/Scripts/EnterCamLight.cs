using UnityEngine;
using System.Collections;

public class EnterCamLight : MonoBehaviour {

	NetworkCommunication net;

	bool active = true;

	void Start() {
		net = GameObject.FindGameObjectWithTag ("NetworkObject").GetComponent<NetworkCommunication> ();
	}

	void Update() {
		if (!PhotonNetwork.isMasterClient) 
			renderer.material.color = (active)? Color.white : Color.black; //////////////////////
	}

	void OnTriggerEnter (Collider other)
    {
		if (active) {
			if (other.tag == "Player") {
				net.Lose ();
			}
		}
    }

	void SetActive(int i) {
		active = (i == 1);
	}

	void Activate(bool b) {
		net.SendObjectActive (transform.parent.name, gameObject.name, (active)? 0 : 1);
	}
}
