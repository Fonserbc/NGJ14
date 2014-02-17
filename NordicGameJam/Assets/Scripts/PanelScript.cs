using UnityEngine;
using System.Collections;

public class PanelScript : MonoBehaviour {

    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;

	public AudioClip pickupAudio;

	private bool onPannel = false;

	private bool activated = false;
	
	// Update is called once per frame
	void Update () {
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
                                //Run Panel animation
                                //Send less stress to morpheus

								if (onPannel) {
									GameObject.Find("NetworkObject").GetComponent<NetworkCommunication>().SendEnergy();
									Destroy(gameObject);
									Debug.Log ("Swipe");
								}
                            }


                        }

                        break;
                }
            }
        }
	}

	void OnTriggerEnter(Collider col) {
		if (!activated) {
			if (col.tag == "Player") {
				onPannel = true;
				audio.clip = pickupAudio;
				audio.Play ();
				activated = true;
				Debug.Log ("Onpannel");
				GameObject.FindGameObjectWithTag("NetworkObject").GetComponent<NetworkCommunication>().SendEnergy();
			}
		}
	}
}
