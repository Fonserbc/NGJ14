using UnityEngine;
using System.Collections;

public class ExclusiveRender : MonoBehaviour {

	public bool renderWhenNeo = true;

	// Use this for initialization
	void Start () {
		if ((PhotonNetwork.isMasterClient && !renderWhenNeo) || (!PhotonNetwork.isMasterClient && renderWhenNeo))
			renderer.enabled = false;
	}
}
