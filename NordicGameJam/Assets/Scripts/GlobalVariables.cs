using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalVariables : MonoBehaviour {

    public List<Vector3> cameraPosistions = new List<Vector3>();

	// Use this for initialization
	void Awake () {
        cameraPosistions.Add(new Vector3(0,0,-10));
        cameraPosistions.Add(new Vector3(18, 0, -10));
        cameraPosistions.Add(new Vector3(36, 0, -10));
	}
	
}
