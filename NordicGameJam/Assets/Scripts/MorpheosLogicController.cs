using UnityEngine;
using System.Collections;

public class MorpheosLogicController : MonoBehaviour {

	GameObject neo;
	float roundTime = 20.0f;
	float roundFuzz = 7.0f; 
	float pressCost = 2.0f;

	private float time = 0.0f;

	private bool capable = true;

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

				if (time < 0.0f) {
					time = 0.0f;

					//Trigger disconnect
					LosePower();
				}
			}
		}
		else {
			/*time -= Time.deltaTime;
			if (time < 0.0f) {
				RegainPower();
			}*/
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
	}

	public void RegainPower() {
		time = roundTime;
		capable = true;
	}
}
