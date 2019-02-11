using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSpeedMod", menuName = "Equipment/ProjectileSpeedMod", order = 1)]
public class ProjectileSpeedModifier : Equipment
{
    [SerializeField]
    float modifier;


    public override void ChangePlayerStats()
    {
        //  Playermanager.ins.TimeBetweenShots = Playermanager.ins.BaseTimeBetweenShots * modifier;
        Playermanager.ins.projectileSpeedModifier *= modifier;
    }

}

