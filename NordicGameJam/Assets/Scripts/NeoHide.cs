using UnityEngine;
using System.Collections;

public class NeoHide : MonoBehaviour {

    bool hideable = false;
    bool hiding = false;
    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;
    AudioClip hideSound;
 
    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;

    void OnTriggerEnter(Collider other)
    {
        hideable = true;
    }

    void OnTriggerExit()
    {
        hideable = false;
    }

	void Awake () {
		hideSound = Resources.Load ("Sound fx/Neo/hide") as AudioClip;
	}
	
	// Update is called once per frame
	void Update () {
        if (hideable&&!hiding)
        {
            if (Input.touchCount > 0)
        {
        foreach (Touch touch in Input.touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began :
                    /* this is a new touch */
                    isSwipe = true;
                    fingerStartTime = Time.time;
                    fingerStartPos = touch.position;
                    break;
 
                case TouchPhase.Canceled :
                    /* The touch is being canceled */
                    isSwipe = false;
                    break;
 
                case TouchPhase.Ended :
                    float gestureTime = Time.time - fingerStartTime;
                    float gestureDist = (touch.position - fingerStartPos).magnitude;
 
                    if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                    {
                        Vector2 direction = fingerStartPos - touch.position;
                        //Vector2 swipeType = Vector2.zero;
 
                        if (Mathf.Abs(direction.x) <= Mathf.Abs(direction.y))
                        {
                            // the swipe is vertical:
                            //swipeType = Vector2.up * Mathf.Sign(direction.y);
                            Hide();
                        }
 
                        
                    }
 
                    break;
                }
            }
        }
        }
        else if (hiding)
        {
            if (Input.touchCount >= 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                { // Just clicked
                    unHide();
                }
            }
        }
	}

    void Hide()
    {
        Debug.Log("now Hiding");
        hiding = true;
        hideable = false;
        audio.PlayOneShot(hideSound);
        GameObject blackCam = Instantiate(Resources.Load("BlackCam")) as GameObject;
        GameObject.Find("Main Camera Neo").camera.enabled = false;
        GameObject.Find("BlackCam").camera.enabled = true;

        //play hide animation
        
    }

    void unHide()
    {
        //Debug.Log("now Hiding");
        hiding = false;
        //hideable = true;
        audio.PlayOneShot(hideSound);
        //GameObject blackCam = Instantiate(Resources.Load("BlackCam")) as GameObject;
        GameObject.Find("Main Camera Neo").camera.enabled = true;
        GameObject.Find("BlackCam").camera.enabled = false;
        Destroy(GameObject.Find("BlackCam"));

        //play hide animation

    }

}
