using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightController : MonoBehaviour {

    public int numberOfRooms;
    public List<bool> lights;
	// Use this for initialization
	void Start () {
        lights = new List<bool>();
        switch (Application.loadedLevelName)
        {
            case "SceneNeo0":
                numberOfRooms = 16;
                break;
            case "SceneNeo1":
                numberOfRooms = 18;
                break;
            case "SceneNeo2":
                numberOfRooms = 20;
                break;
        }
        for (int i = 0; i < numberOfRooms; i++)
        {
            lights.Add(true);
        }
	}

    void setLight(int lightNum)
    {
        if (lights[lightNum]){
            lights[lightNum] = false;
        }
            
        else
        {
            lights[lightNum] = true;
        }
            
    }
}
