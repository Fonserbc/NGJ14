using UnityEngine;
using System.Collections;

public class NetworkNeoPosition : MonoBehaviour {

	private NetworkCommunication network;

	public float period = 1.0f;

	private float time = 0.0f;

	// Use this for initialization
	void Start () {
		network = GameObject.FindGameObjectWithTag ("NetworkObject").GetComponent<NetworkCommunication> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time > period) {
			network.SendNeoPosition(transform.position);

			time = 0.0f;
		}
	}
}
