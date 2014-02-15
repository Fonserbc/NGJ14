using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightController : MonoBehaviour {

    public int numberOfRooms;
    public List<bool> lights = new List<bool>();
	// Use this for initialization
	void Start () {
        for (int i = 0; i < numberOfRooms; i++)
        {
            lights.Add(true);
        }
	}

    void setLight(int lightNum)
    {
        if (lights[lightNum]){
            lights[lightNum] = false;
            //change Kornel's script
        }
            
        else
        {
            lights[lightNum] = true;
            //change Kornel's script
        }
            
    }
}
