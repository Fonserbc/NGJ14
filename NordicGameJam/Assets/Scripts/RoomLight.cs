using UnityEngine;
using System.Collections;

public class RoomLight : MonoBehaviour {

	NetworkCommunication net;

	// Use this for initialization
	void Start () {
		net = GameObject.FindGameObjectWithTag ("NetworkObject").GetComponent<NetworkCommunication> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount >= 1)
		{
			for (int i = 0; i < Input.touchCount; ++i) {
				if (Input.GetTouch(i).phase == TouchPhase.Began) { // Just clicked
					Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
					Vector2 touchPos = new Vector2(wp.x, wp.y);
					if (collider2D) {
						if (collider2D == Physics2D.OverlapPoint(touchPos))
						{
							SwitchActive();
							break;
						}
					}
					else {
						RaycastHit hit;
						if (Physics.Raycast(wp, Camera.main.transform.forward, out hit, 100.0f)) {
							if (hit.collider == collider) {
								SwitchActive();
								break;
							}
						}
					}
				}
			}
		}
		
		if (Input.GetMouseButtonDown (0)) {
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (collider2D) {
				if (collider2D == Physics2D.OverlapPoint(touchPos))
				{
					SwitchActive();
				}
			}
			else {
				RaycastHit hit;
				if (Physics.Raycast(wp, Camera.main.transform.forward, out hit, 100.0f)) {
					if (hit.collider == collider) {
						SwitchActive();
					}
				}
			}
		}
	}

	void SwitchActive() {
		net.TurnLights (transform.parent.tag);
	}
}
