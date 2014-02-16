using UnityEngine;
using System.Collections;

public class MoveUpStairs : MonoBehaviour {

    public GameObject nextRoomLeft;
    public GameObject nextRoomRight;
    float levelHeight = 9.0f;
    bool swipeable = false;
    //As the Neo walks through a door the camera should be moved to that scene

    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;

    private CameraPositionAsObject camFollow;
    //private GlobalVariables global;
    private Transform player;

    void Start()
    {
        camFollow = Camera.main.GetComponent<CameraPositionAsObject>();
        //global = GameObject.Find ("Manager").GetComponent<GlobalVariables> ();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (swipeable)
        {
            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            /* this is a new touch */
                            isSwipe = true;
                            fingerStartTime = Time.time;
                            fingerStartPos = touch.position;
                            break;

                        case TouchPhase.Canceled:
                            /* The touch is being canceled */
                            isSwipe = false;
                            break;

                        case TouchPhase.Ended:
                            float gestureTime = Time.time - fingerStartTime;
                            float gestureDist = (touch.position - fingerStartPos).magnitude;

                            if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                            {
                                Vector2 direction = fingerStartPos - touch.position;
                                //Vector2 swipeType = Vector2.zero;

                                if (Mathf.Abs(direction.x) <= Mathf.Abs(direction.y))
                                {
                                    if (player.position.x < Camera.main.transform.position.x){
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
                                       
                                    Debug.Log(player.position.y + " " + levelHeight);

                                    GameObject.Find("Neo").transform.position = new Vector3(player.position.x, player.position.y+levelHeight, 0);
                                    swipeable = false;

                                }


                            }

                            break;
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        swipeable = true;

    }

     void OnTriggerExit(Collider other)
    {
        swipeable = false;
        
    }
}
