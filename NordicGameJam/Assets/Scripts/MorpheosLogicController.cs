using UnityEngine;
using System.Collections;

public class MorpheosLogicController : MonoBehaviour {

	GameObject neo;

	// Use this for initialization
	void Start () {
		neo = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetNeoPosition (Vector3 pos) {
		neo.transform.position = pos;
	}
}
