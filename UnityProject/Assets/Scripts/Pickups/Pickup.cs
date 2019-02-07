using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : ScriptableObject , IPickup
{
    [SerializeField]
    public GameObject worldObject;
    public string itemName;
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
