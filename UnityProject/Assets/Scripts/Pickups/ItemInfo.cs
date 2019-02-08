using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Empty item", menuName = "Consumables/Dont do shit", order = 1)]
public class ItemInfo : Pickup
{
    public virtual void PickedUp()
    {
        Debug.Log("Item picked up");
        
    }
    public virtual bool CanBePickedUp()
    {
        return true;
    }

}
