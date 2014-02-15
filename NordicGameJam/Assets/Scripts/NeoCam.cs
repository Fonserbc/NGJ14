using UnityEngine;
using System.Collections;

public class NeoCam : MonoBehaviour {

	public int camNumNeo;
    private bool on = true;

    public void receiveCamTrigger()
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
