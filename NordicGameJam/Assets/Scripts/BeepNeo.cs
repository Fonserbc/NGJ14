using UnityEngine;
using System.Collections;

public class BeepNeo : MonoBehaviour {

	public AudioClip beep;

	private MorpheosLogicController m;

	// Use this for initialization
	void Start () {
		m = GameObject.Find ("Manager").GetComponent < MorpheosLogicController >();
	}
	
	void Beep() {
		if (m.Capable()) audio.PlayOneShot (beep);
	}
}
