using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
    public int nextRoomLeft;
    public int nextRoomRight;
	//As the Neo walks through a door the camera should be moved to that scene

    void OnTriggerEnter(Collider other){
        if (GameObject.Find("Main Camera").transform.position == GameObject.Find("Manager").GetComponent<GlobalVariables>().cameraPosistions[nextRoomRight])
            GameObject.Find("Main Camera").transform.position = GameObject.Find("Manager").GetComponent<GlobalVariables>().cameraPosistions[nextRoomLeft];
        if (GameObject.Find("Main Camera").transform.position == GameObject.Find("Manager").GetComponent<GlobalVariables>().cameraPosistions[nextRoomLeft])
            GameObject.Find("Main Camera").transform.position = GameObject.Find("Manager").GetComponent<GlobalVariables>().cameraPosistions[nextRoomRight];
    }
    
}
