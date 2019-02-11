using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Heal", menuName = "Consumables/Heal player", order = 1)]
public class PlayerHeal : ItemInfo
{
    [SerializeField]
    int healAmount = 1;
    [SerializeField]
    bool ignoreMaxHP = false;

    public override bool CanBePickedUp()
    {

        Playermanager pm = Playermanager.ins;
        if (pm.CurrentHP < pm.MaxHP)
        {
            return true;
        }
        else if (ignoreMaxHP)
        {
            return true;
        }
            return false;
    }
    public override void PickedUp()
    {

        if (ignoreMaxHP)
        {
            Playermanager.ins.CurrentHP += healAmount;
        }
        else
        {
            Playermanager.ins.Heal(healAmount);
        }
        base.PickedUp();
    }
    
}
