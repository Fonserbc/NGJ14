using UnityEngine;
using System.Collections;

public class StartButtons : MonoBehaviour {
	
	public GameObject camPos;
	public GameObject networkObject;

	private bool activated = false;

	// Use this for initialization
	void Start () {
	
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
		if (activated) return;
		Camera.main.SendMessage("SetFollow", camPos);
		GameObject aux = (GameObject) GameObject.Instantiate(networkObject, transform.position, transform.rotation);

		GameObject gui = GameObject.Find ("GUI");

		aux.SendMessage ("SetGameName", gui.GetComponent<ChooseMenuGUI> ().gameName);
		activated = true;

		gui.SetActive (false);
	}
}
