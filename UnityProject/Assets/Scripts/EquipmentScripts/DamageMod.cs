using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMod : Equipment
{
    [SerializeField]
    float modifier;


    public override void ChangePlayerStats()
    {

        Playermanager.ins.damageModifier *= modifier;
    }
}
