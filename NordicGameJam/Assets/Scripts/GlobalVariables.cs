using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalVariables : MonoBehaviour {

    public List<Vector3> cameraPositions;
    public List<Vector3> switchPositions;
    public int currentRoom = 0;
    GameObject switches;

	// Use this for initialization
	void Awake () {
        switchPositions = new List<Vector3>();
        cameraPositions = new List<Vector3>();
        switches = GameObject.Find("lightSwitches");
        cameraPositions.Add(new Vector3(0,0,-10));
        cameraPositions.Add(new Vector3(18, 0, -10));
        cameraPositions.Add(new Vector3(36, 0, -10));

	}

    
	
}
