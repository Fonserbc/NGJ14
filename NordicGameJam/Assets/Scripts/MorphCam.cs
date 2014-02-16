using UnityEngine;
using System.Collections;

public class MorphCam : MonoBehaviour {

    public int CamNum;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.touchCount >= 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            { // Just clicked
                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Vector2 touchPos = new Vector2(wp.x, wp.y);
                if (collider2D == Physics2D.OverlapPoint(touchPos))
                {
                    //send CamNum to corresponding script
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 touchPos = new Vector2(wp.x, wp.y);
            if (collider2D == Physics2D.OverlapPoint(touchPos))
            {
                //send CamNum to corresponding script
            }
        }
	}
}
