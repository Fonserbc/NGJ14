using UnityEngine;
using System.Collections;

public class TimeBar : MonoBehaviour {

	MorpheosLogicController controller;
	float maxScale = 0.975f;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("Manager").GetComponent<MorpheosLogicController> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(Mathf.Lerp (transform.lossyScale.x, 0.975f * controller.GetTimeLeftFactor (), Time.deltaTime*speed), transform.lossyScale.y, transform.lossyScale.z);
	}
}
