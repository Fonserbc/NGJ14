﻿using UnityEngine;
using System.Collections;

public class CameraPositionAsObject : MonoBehaviour {

	public GameObject followObject;
	public float speed = 1.0f;
	public Vector2 camScale;
	public float inverted = 1.0f;

	private bool following = false;

	// Use this for initialization
	void Start () {
		if (followObject)
			SetFollow (followObject);

		float ratio = (float)Screen.height / (float)Screen.width;
	
		if (inverted*ratio < (9.0f / 16.0f))
			Camera.main.orthographicSize = (ratio * 16.0f*camScale.x) / 2.0f;
		else
			Camera.main.orthographicSize = 9.0f*camScale.y / 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (following) {
			transform.position = Vector3.Lerp(transform.position, followObject.transform.position, speed*Time.deltaTime);
			transform.rotation = Quaternion.Slerp(transform.rotation, followObject.transform.rotation, speed*Time.deltaTime);
		}
	}

	public void SetFollow (GameObject o) {
		followObject = o;
		following = true;
	}

	public Transform GetFollow() {
		return followObject.transform;
	}

	// Releases the camera of the current following object
	public void Release () {
		following = false;
	}
}
