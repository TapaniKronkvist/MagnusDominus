using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : ScriptableObject , IPickup
{

    public GameObject worldObject;
    public string itemName;
    [TextArea(3,10)]
    public string description;

    public GameObject WorldObject
    {
        get
        {
            if (worldObject != null)
            {
                return worldObject;
            }
            else return GameObject.CreatePrimitive(PrimitiveType.Sphere);

        }
    }
}
