using UnityEngine;
using System.Collections;

public class NeoCharacterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        #if UNITY_EDITOR
        #endif

        #if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Vector3 worldSpaceHitPoint = hitInfo.point;
            }
        }
        #endif
        }
}
