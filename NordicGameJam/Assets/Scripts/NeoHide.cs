using UnityEngine;
using System.Collections;

public class NeoHide : MonoBehaviour {

    bool hideable = false;
    bool hiding = false;
    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;
 
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
	
	// Update is called once per frame
	void Update () {
        if (hideable)
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
	}

    void Hide()
    {
        Debug.Log("now Hiding");
        hiding = true;
        //play hide animation
        
    }
}
