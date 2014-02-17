using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
    public GameObject nextRoomLeft;
	public GameObject nextRoomRight;
	//As the Neo walks through a door the camera should be moved to that scene

	private CameraPositionAsObject camFollow;
	//private GlobalVariables global;
	private GameObject player;

	void Start() {
		camFollow = Camera.main.GetComponent<CameraPositionAsObject> ();
		//global = GameObject.Find ("Manager").GetComponent<GlobalVariables> ();
		player = GameObject.Find ("Neo");
	}

    void OnTriggerEnter(Collider other){
		int c = GameObject.Find ("Manager").GetComponent<GlobalVariables> ().currentRoom;


        if (player.transform.position.x < Camera.main.transform.position.x)
        {
            camFollow.SetFollow(nextRoomLeft);
			GameObject.Find("Manager").GetComponent<LightController>().CheckLights(c, c - 1);
			
			GameObject.Find("Manager").GetComponent<GlobalVariables>().currentRoom--;

			player.SendMessage("UpdateTarget", transform.position.x - transform.lossyScale.x*1.5f);
        }

		else if (player.transform.position.x > Camera.main.transform.position.x)
        {
            camFollow.SetFollow(nextRoomRight);
			GameObject.Find("Manager").GetComponent<LightController>().CheckLights(c, c + 1);
			
			GameObject.Find("Manager").GetComponent<GlobalVariables>().currentRoom++;

			player.SendMessage("UpdateTarget", transform.position.x + transform.lossyScale.x*1.5f);
        }
	}
    
}
