using UnityEngine;
using System.Collections;

public class RestartOnClick : MonoBehaviour {

	NetworkCommunication net;

	// Use this for initialization
	void Start () {
		net = GameObject.FindGameObjectWithTag ("NetworkObject").GetComponent<NetworkCommunication> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (collider2D && renderer.enabled) {
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
	}

	void GameOver() {
		renderer.enabled = true;
	}

	void Activate() {
		net.RestartLevel ();
	}
}
