using UnityEngine;
using System.Collections;

public class ChooseMenuGUI : MonoBehaviour {

	public string gameName = "DisclosureGameName";

	void Start() {
		gameName = "DisclosureGameName";
	}

	void OnGUI() {
		int width = Screen.width / 5;
		int height = Screen.height / 10;

		gameName = GUI.TextField (new Rect (Screen.width/2, (int) ((float)Screen.height * 0.8f), width, height), gameName, 20);
	}
}
