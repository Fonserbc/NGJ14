using UnityEngine;
using System.Collections;

public class LightCount : MonoBehaviour {

    Transform[] tonsOfLights;

	// Use this for initialization
	void Start () {
        tonsOfLights = GameObject.GetComponentInChildren<Transform>();
        for (int i = 0; i < tonsOfLights.length; i++)
            GameObject.Find("Manager").GetComponent<GlobalVariables>().switchPositions.Add(tonsOfLights[i].position);
	}
	
}
