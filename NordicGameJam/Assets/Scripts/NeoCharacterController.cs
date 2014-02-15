/*using UnityEngine;
using System.Collections;

public class NeoCharacterController : MonoBehaviour {

    Vector3 worldSpaceHitPoint;
    Ray ray;
    RaycastHit hitInfo;
    GameObject obj = (GameObject)GameObject.Find("IntersectPlane");
    //Collider coll;
    float hitDist;

	// Use this for initialization
	void Start () {
        //coll = obj.collider;
	}
	
	// Update is called once per frame
	void Update () {
        //#if UNITY_EDITOR
        if (Input.GetButtonDown ("Fire1")) {
            
            Debug.Log("FIRE");
			// Construct a ray from the current mouse coordinates
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            
            if (coll.Raycast(ray,out hitInfo, hitDist))
            {
                worldSpaceHitPoint = ray.GetPoint(hitDist);
            }
		}
        //#endif

        //#if UNITY_ANDROID
        /*if (Input.touchCount > 0)
        {
         *  playerPlane = new Plane(Vector3.up, transform.position);
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            
            if (Physics.Raycast(ray, out hitInfo))
            {
                worldSpaceHitPoint = hitInfo.point;
            }
        }*/
        //#endif

        /*GameObject.Find("Neo").GetComponent<MoveNeo>().UpdateTarget(worldSpaceHitPoint.y);
        }
}*/
