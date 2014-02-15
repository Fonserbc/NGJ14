using UnityEngine;
using System.Collections;

public class MoveNeo : MonoBehaviour {

    float _targetPos;
    public float speed = 0.5f;
    //bool direction;

	// Use this for initialization
	void Start () {
        _targetPos = transform.position.x;
	}
	
	// Update is called once per frame
    void Update()
    {
        /*if (transform.position.x < _targetPos)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else if (transform.position.x > _targetPos)
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }*/
		rigidbody.MovePosition (Vector3.Lerp (transform.position, new Vector3 (_targetPos, transform.position.y, transform.position.z), Time.deltaTime*speed));
    }

    public void UpdateTarget(float targetPos)
    {
        _targetPos = targetPos;
    }
}
