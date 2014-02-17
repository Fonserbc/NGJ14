using UnityEngine;
using System.Collections;

public class MoveNeo : MonoBehaviour {

    float _targetPos;
    bool direction;
    public AudioClip runSound;

	float speed = 10.0f;

	Animator anim;

	// Use this for initialization
	void Start () {
        _targetPos = transform.position.x;
        direction = true;

		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
    void Update()
    {
        Vector3 theScale = transform.localScale;
        if (transform.position.x < _targetPos)
        {
            if (!direction)
            {
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            direction = true;
            
        }
        else if (transform.position.x > _targetPos)
        {
            if (direction)
            {
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            direction = false;
        }

        if (Mathf.Abs (transform.position.x - _targetPos) > 0.1f) {
			if (!audio.isPlaying) {
				audio.loop = true;
				audio.clip = runSound;
				audio.Play();
			}
			
			anim.speed = 2.0f;
			float nextPos = ((direction)? 1 : -1) * speed * Time.deltaTime;
			float nextAbsPos = transform.position.x + nextPos;
			if (nextAbsPos > _targetPos && direction) nextPos = _targetPos - transform.position.x; 
			else if (nextAbsPos < _targetPos && !direction) nextPos = _targetPos - transform.position.x ;
			rigidbody.MovePosition (transform.position + new Vector3(nextPos, 0, 0));
			anim.SetBool ("run", true);
		} else {
			if (audio.isPlaying) audio.Stop();
			anim.speed = 1.0f;
			anim.SetBool ("run", false);
			_targetPos = transform.position.x;
		}
    }

    public void UpdateTarget(float targetPos)
    {
        _targetPos = targetPos;
    }

	void OnTriggerEnter (Collider c) {
		if (c.tag == "Camera") {
			c.gameObject.SendMessage("LooseIfActive");		
		}
	}
}
