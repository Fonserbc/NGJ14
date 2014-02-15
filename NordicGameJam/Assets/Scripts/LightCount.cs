using UnityEngine;
using System.Collections;

public class LightCount : MonoBehaviour {

    Transform[] tonsOfLights;

	// Use this for initialization
	void Start () {
        tonsOfLights = gameObject.GetComponentsInChildren<Transform>();
        for (int i = 0; i < tonsOfLights.Length; i++)
            GameObject.Find("Manager").GetComponent<GlobalVariables>().switchPositions.Add(tonsOfLights[i].position);
	}
	
}
