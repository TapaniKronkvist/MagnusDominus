using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Firespeedmod", menuName = "Equipment/FirerateMod", order = 1)]
public class FirerateMod : Equipment
{
    [SerializeField]
    float modifier;


    public override void ChangePlayerStats()
    {

        Playermanager.ins.timeBetweenShotsModifier *= modifier;
    }

}
