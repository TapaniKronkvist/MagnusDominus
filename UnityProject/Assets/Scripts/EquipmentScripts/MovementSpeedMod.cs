using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveSpeedMod", menuName = "Equipment/MovementSpeedMod", order = 1)]
public class MovementSpeedMod : Equipment
{
    [SerializeField]
    float modifier;


    public override void ChangePlayerStats()
    {

        Playermanager.ins.movementSpeedModifier *= modifier;
    }

}

