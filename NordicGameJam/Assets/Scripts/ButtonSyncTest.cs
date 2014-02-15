using UnityEngine;
using System.Collections;

public class ButtonSyncTest : MonoBehaviour {

	NetworkCommunication network;
	float lastPressedTime = 0.0f;
	public int id;

	private bool red = true;

	void Start() {
		network = GameObject.FindGameObjectWithTag ("NetworkObject").GetComponent<NetworkCommunication> ();
		lastPressedTime = Time.time;
		renderer.material.color = Color.red;
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount >= 1)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began) { // Just clicked
				Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				Vector2 touchPos = new Vector2(wp.x, wp.y);
				if (collider2D == Physics2D.OverlapPoint(touchPos))
				{
					Activate();
				}
			}
		}
		
		if (Input.GetMouseButtonDown (0)) {
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (collider2D == Physics2D.OverlapPoint(touchPos))
			{
				Activate();
			}	
		}


	}

	void Activate() {
		network.ActivateButton (id);
	}

	public void SwitchColor() {
		if (red) {
			renderer.material.color = Color.blue;
		} else {
			renderer.material.color = Color.red;
		}
		red = !red;
	}
}
