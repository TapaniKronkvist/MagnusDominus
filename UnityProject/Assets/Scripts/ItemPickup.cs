using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Item
{
    [SerializeField]
    public ItemInfo item;

    public override void CreateWorldViz()
    {
        pickup = item;
        base.CreateWorldViz();
    }

    public override void PickUp()
    {
        if (item.CanBePickedUp())
        {
            item.PickedUp();
            Destroy(gameObject);
        }



    }
}
