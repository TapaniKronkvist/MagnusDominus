using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineShot : MonoBehaviour
{

    GameObject playerObject;
    Playermanager pm;

    // Update is called once per frame
    void Update()
    {
        if (pm == null) pm = Playermanager.ins;
        if (playerObject == null)
        {
            playerObject = pm.playerObject;
        }
        else
        {

        }
    }
}
