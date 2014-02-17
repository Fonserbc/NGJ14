using UnityEngine;
using System.Collections;

public class MorpheosLogicController : MonoBehaviour {

	GameObject neo;
	float roundTime = 30.0f;
	float roundFuzz = 7.0f; 
	float pressCost = 2.0f;

	private float time = 0.0f;

	private bool capable = true;

	public AudioClip lastBeeps;
	public AudioClip finalBeeps;

	public GUIText lostText;

	// Use this for initialization
	void Start () {
		neo = GameObject.FindGameObjectWithTag ("Player");
		time = roundTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (capable) {
			if (time > 0.0f) {
				time -= Time.deltaTime;

				if (time < 5.0f) {
					if (!audio.isPlaying) {
						audio.clip = lastBeeps;
						audio.Play();
					}
				}

				if (time < 0.0f) {
					time = 0.0f;

					//Trigger disconnect
					LosePower();
				}
			}
		}
		else {
			time -= Time.deltaTime;
			if (time < 0.0f) {
				//RegainPower();
			}
		}
	}

	public void SetNeoPosition (Vector3 pos) {
		neo.transform.position = pos;
	}

	public float GetTimeLeftFactor() {
		if (capable) return time / roundTime;
		else return 0.0f;
	}

	public void ObjectPressed() {
		time -= pressCost;

		if (time < 0.0f) {			
			LosePower();
		}
	}

	public void LosePower() {
		capable = false;
		time = roundFuzz;
		audio.PlayOneShot (finalBeeps);
		lostText.enabled = true;
		transform.parent.GetComponent<NoiseEffect> ().enabled = false;
	}

	public void RegainPower() {
		time = roundTime;
		capable = true;
		lostText.enabled = false;
		transform.parent.GetComponent<NoiseEffect> ().enabled = true;
	}

	public bool Capable() {
		return capable;
	}
}
