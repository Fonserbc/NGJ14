using UnityEngine;
using System.Collections;

public class NeoCharacterController : MonoBehaviour {

    Vector3 worldSpaceHitPoint;
    Ray ray;
    RaycastHit hitInfo;
    //GameObject obj = (GameObject)GameObject.Find("IntersectPlane");
    //Collider coll;
    float hitDist;
    Vector3 wp;
    Vector2 touchPos;

	// Use this for initialization
	void Start () {
        //coll = obj.collider;
	}
	
	// Update is called once per frame
	void Update () {
        //#if UNITY_EDITOR
        /*if (Input.GetMouseButtonDown(0))
        {
            wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos = new Vector2(wp.x, wp.y);
            GameObject.Find("Neo").GetComponent<MoveNeo>().UpdateTarget(wp.x);
            
        }*/
        //#endif

        //#if UNITY_ANDROID
        if (Input.touchCount >= 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            { // Just clicked
                wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                touchPos = new Vector2(wp.x, wp.y);
                GameObject.Find("Neo").GetComponent<MoveNeo>().UpdateTarget(wp.x);
                
            }
        }
        //#endif
        //Debug.Log(wp);
        
        }
}
