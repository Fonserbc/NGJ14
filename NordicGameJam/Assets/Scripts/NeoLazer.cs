using UnityEngine;
using System.Collections;

public class NeoLazer : MonoBehaviour {

    public int lazerNumNeo;
    private bool on = true;

    public void receiveLazerTrigger()
    {
        if (on)
        {
            on = false;
        }
        else
        {
            on = true;
        }
    }
}
