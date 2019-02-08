using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    ItemPickup itemPickup;
    [SerializeField]
    EquipmentPickup equipmentPickup;

    public Pickup testPickup;

    public void SpawnItem(Pickup theItem)
    {

        if( theItem is Equipment)
        {

           EquipmentPickup newObj = Instantiate(equipmentPickup);
            newObj.transform.position = transform.position;
            newObj.equipment = theItem as Equipment;
            newObj.pickup = theItem;
            newObj.CreateWorldViz();
        }else if (theItem is ItemInfo)
        {
            ItemPickup newObj = Instantiate(itemPickup);
            newObj.transform.position = transform.position;
            newObj.item = theItem as ItemInfo;
            newObj.CreateWorldViz();
        }


        gameObject.SetActive(false);
    }
}
