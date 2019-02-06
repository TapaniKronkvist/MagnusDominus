using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Empty Equipment", menuName = "Equipment/BaseEq", order = 1)]
public class Equipment : ScriptableObject
{
    public List<Equipment> conflictingItems;
    public string equipmentName;
    public string description;
    public bool allowDuplicates = true;
    public virtual void ChangePlayerStats()
    {
        Debug.Log(equipmentName + " is Changing stats");
    }
}
