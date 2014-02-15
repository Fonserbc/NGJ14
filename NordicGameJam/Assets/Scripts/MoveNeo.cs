using UnityEngine;
using System.Collections;

public class MoveNeo : MonoBehaviour {

    float _targetPos;
    float speed = 0.2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (transform.position.y < _targetPos)
        {
            transform.Translate(transform.forward * speed);
        }
        if (transform.position.y > _targetPos)
        {
            transform.Translate(-transform.forward * speed);
        }
    }

    public void UpdateTarget(float targetPos)
    {
        _targetPos = targetPos;
    }
}
