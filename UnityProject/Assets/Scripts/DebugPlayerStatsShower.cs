using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugPlayerStatsShower : MonoBehaviour
{
    [SerializeField]
    Text text;
    Playermanager pm;

    private void Start()
    {
        pm = Playermanager.ins;
    }
    private void Update()
    {
        string allitems = "";
        if (pm != null && pm.playerEquipment != null)
        {
            for (int i = 0; i < Playermanager.ins.playerEquipment.Count; i++)
            {
                allitems +=   Playermanager.ins.playerEquipment[i].equipmentName;
                allitems += ", ";
            }
        }
        text.text = string.Format("MaxHP: {0}, CurrentHP: {1}, TimeBetweenShots: {2}, MovementSpeed: {3}, projectile speed mod: {4}, invulTime: {5} ProjectileSpeedMod: {6}", pm.MaxHP, pm.CurrentHP, pm.TimeBetweenShots, pm.BaseMovementSpeed * pm.movementSpeedModifier, pm.projectileSpeedModifier, pm.postDamageInvulTime, pm.projectileSpeedModifier) + "\n Items:\n" + allitems;
    }

}
