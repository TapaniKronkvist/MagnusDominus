using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugPlayerStatsShower : MonoBehaviour
{
    [SerializeField]
    Text playerInfoText;
    [SerializeField]
    Text bossText;
    Playermanager pm;

    private void Start()
    {
        pm = Playermanager.ins;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        string allitems = "";
        if (pm != null && pm.playerEquipment != null)
        {
            for (int i = 0; i < Playermanager.ins.playerEquipment.Count; i++)
            {
                allitems +=   Playermanager.ins.playerEquipment[i].itemName;
                allitems += ", ";
            }
        }
        playerInfoText.text = string.Format("MaxHP: {0}, CurrentHP: {1}, TimeBetweenShots: {2}, MovementSpeed: {3}, projectile speed mod: {4}, invulTime: {5} ProjectileSpeedMod: {6}", pm.MaxHP, pm.CurrentHP, pm.TimeBetweenShots, pm.BaseMovementSpeed * pm.movementSpeedModifier, pm.projectileSpeedModifier, pm.postDamageInvulTime, pm.projectileSpeedModifier) + "\n Items:\n" + allitems;
        string bosses = "";
        for (int i = 0; i < WorldManager.ins.DefeatedBosses.Count; i++)
        {
            switch (WorldManager.ins.DefeatedBosses[i])
            {
                case WorldManager.Bosses.fire:
                    bosses += "Fire";
                    break;
                case WorldManager.Bosses.nature:
                    bosses += "Nature";
                    break;
                case WorldManager.Bosses.stone:
                    bosses += "Stone";
                    break;
                default:
                    break;
            }
        }
        bossText.text = bosses;

    }

}
