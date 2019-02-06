using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InvulTimeMod", menuName = "Equipment/InvulTimeMod", order = 1)]
public class InvulTimeMod : Equipment
{
    [SerializeField]
    float modifier;


    public override void ChangePlayerStats()
    {

        Playermanager.ins.postDamageInvulTimeModifier *= modifier;
    }

}
