using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
    public GameObject nextRoomLeft;
	public GameObject nextRoomRight;
	//As the Neo walks through a door the camera should be moved to that scene

	private CameraPositionAsObject camFollow;
	//private GlobalVariables global;
	private Transform player;

	void Start() {
		camFollow = Camera.main.GetComponent<CameraPositionAsObject> ();
		//global = GameObject.Find ("Manager").GetComponent<GlobalVariables> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

    void OnTriggerEnter(Collider other){
        if (player.position.x < Camera.main.transform.position.x)
        {
            camFollow.SetFollow(nextRoomLeft);
            GameObject.Find("Manager").GetComponent<GlobalVariables>().currentRoom--;
            if (!GameObject.Find("Manager").GetComponent<LightController>().lights[GameObject.Find("Manager").GetComponent<GlobalVariables>().currentRoom])
            {
                GameObject.Find("Manager").GetComponent<LightController>().boolLights();
            }
        }

        else if (player.position.x > Camera.main.transform.position.x)
        {
            camFollow.SetFollow(nextRoomRight);
            GameObject.Find("Manager").GetComponent<GlobalVariables>().currentRoom++;
            if (!GameObject.Find("Manager").GetComponent<LightController>().lights[GameObject.Find("Manager").GetComponent<GlobalVariables>().currentRoom])
            {
                GameObject.Find("Manager").GetComponent<LightController>().boolLights();
            }
        }
	}
    
}
