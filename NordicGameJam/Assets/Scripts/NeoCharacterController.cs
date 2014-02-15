using UnityEngine;
using System.Collections;

public class NeoCharacterController : MonoBehaviour {

    Vector3 worldSpaceHitPoint;
    Ray ray;
    RaycastHit hitInfo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //#if UNITY_EDITOR
        if (Input.GetButtonDown ("Fire1")) {
			// Construct a ray from the current mouse coordinates
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                worldSpaceHitPoint = hitInfo.point;
            }
		}
        //#endif

        //#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            
            if (Physics.Raycast(ray, out hitInfo))
            {
                worldSpaceHitPoint = hitInfo.point;
            }
        }
        //#endif

        GameObject.Find("Neo").GetComponent<MoveNeo>().UpdateTarget(worldSpaceHitPoint.x);
        }
}
