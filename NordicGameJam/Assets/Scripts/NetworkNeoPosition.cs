using UnityEngine;
using System.Collections;

public class NetworkNeoPosition : MonoBehaviour {

	private NetworkCommunication network;

	public float period = 2.0f;

	private float time = 0.0f;

	// Use this for initialization
	void Start () {
		GameObject aux = GameObject.FindGameObjectWithTag ("NetworkObject");
		if (aux)
			network = aux.GetComponent<NetworkCommunication> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (network) {
			time += Time.deltaTime;

			if (time > period) {
				network.SendNeoPosition(transform.position);

				time = 0.0f;
			}
		}
	}
}
