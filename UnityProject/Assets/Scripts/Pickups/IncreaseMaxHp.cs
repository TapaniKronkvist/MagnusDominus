using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Heal", menuName = "Consumables/Heal player", order = 1)]
public class IncreaseMaxHp : ItemInfo
{
    [SerializeField]
    int amount = 1;
    [SerializeField]
   // bool ignoreMaxHP = false;

    public override bool CanBePickedUp()
    {

        return true;
    }
    public override void PickedUp()
    {
        Playermanager.ins.MaxHP++;
    }

}
