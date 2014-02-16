using UnityEngine;
using System.Collections;

public class flickering : MonoBehaviour {
	public Light a;
	float nTime = Time.time;
	float ch = 2;
	bool sw = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > ch){
			if(sw == true){
				a.intensity = 3.2f+(Random.Range(0,1)-0.5f);
				sw = false;
			}else{
				a.intensity = 2;
				sw = true;
			}

			ch = Time.time + Random.Range(0,1.9f);

		}

	}
}
