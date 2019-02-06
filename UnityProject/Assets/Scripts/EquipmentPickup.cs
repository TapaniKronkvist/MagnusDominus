using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPickup : Item
{
    [SerializeField]
    Equipment equipment;



    public override void PickUp()
    {
        if (equipment.allowDuplicates && !CheckConflictingItems())
        {
            
            Playermanager.ins.PickUpEquipment(equipment);
            Destroy(gameObject);
        } else if (!Playermanager.ins.playerEquipment.Contains(equipment) && !CheckConflictingItems())
        {
            Playermanager.ins.PickUpEquipment(equipment);
            Destroy(gameObject);
        }

    }

    bool CheckConflictingItems()
    {
        if (equipment.conflictingItems != null)
        {
            for (int i = 0; i < equipment.conflictingItems.Count; i++)
            {
                if (Playermanager.ins.playerEquipment.Contains(equipment.conflictingItems[i]))
                {
                    return true;
                    break;
                }
            }
        }
        return false;
    }

}
