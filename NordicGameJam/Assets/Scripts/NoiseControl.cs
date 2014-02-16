using UnityEngine;
using System.Collections;

public class NoiseControl : MonoBehaviour {

	MorpheosLogicController controller;

	NoiseEffect noise;
	SpriteRenderer overlay;

	float minAlpha;
	float maxNoise = 2.0f;

	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("Manager").GetComponent<MorpheosLogicController> ();
		noise = Camera.main.GetComponent<NoiseEffect> ();
		overlay = Camera.main.transform.Find ("CRT_Overlay").GetComponent<SpriteRenderer> ();

		minAlpha = overlay.material.color.a;
		noise.grainSize = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		float f = 1.0f - controller.GetTimeLeftFactor ();
		if (f >= 0.5f) {
			f -= 0.5f;
			f *= 2.0f;
		}
		else f = 0.0f;
		noise.grainSize = f * maxNoise;
		overlay.material.color = new Color(overlay.material.color.r, overlay.material.color.g, overlay.material.color.b, Mathf.Lerp (minAlpha, 1.0f, f));
	}
}
