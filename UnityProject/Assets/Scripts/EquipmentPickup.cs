using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPickup : Item
{
    [SerializeField]
    Equipment equipment;



    public override void PickUp()
    {
        if (equipment.allowDuplicates)
        {
            Playermanager.ins.PickUpEquipment(equipment);
            Destroy(gameObject);
        } else if (!Playermanager.ins.playerEquipment.Contains(equipment))
        {
            Playermanager.ins.PickUpEquipment(equipment);
            Destroy(gameObject);
        }

    }

}
