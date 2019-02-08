using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Empty Equipment", menuName = "Equipment/BaseEq", order = 1)]
public class Equipment : Pickup
{

    public List<Equipment> conflictingItems;

    public bool allowDuplicates = true;



    public virtual void ChangePlayerStats()
    {
        Debug.Log(itemName + " is Changing stats");
    }
}
