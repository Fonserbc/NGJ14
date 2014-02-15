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
			Debug.Log("touched");
			for (int i = 0; i < Input.touchCount; ++i) {
				Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
				Vector2 touchPos = new Vector2(wp.x, wp.y);
				if (collider2D == Physics2D.OverlapPoint(touchPos) && Input.GetTouch(i).phase == TouchPhase.Began)
				{ // && (Time.time - lastPressedTime > 0.5f)
					Activate();
					Debug.Log("in");
					lastPressedTime = Time.time;
					break;
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
		//network.ActivateButton (id);
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
