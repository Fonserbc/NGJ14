using UnityEngine;
using System.Collections;

public class MoveNeo : MonoBehaviour {

    float _TargetPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position < targetPos)
        {
           
        }
	}

    void UpdateTarget(float TargetPos)
    {
        _TargetPos = TargetPos;
    }
}
