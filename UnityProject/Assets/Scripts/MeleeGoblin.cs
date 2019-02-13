using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeGoblin : Goblin
{
    [SerializeField]
    float meleeRange;

    protected override void Update()
    {

        if (Playermanager.ins.playerObject != null && Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < range)
        {
            if (cooldown < cooldownMax)
            {
                cooldown += Time.deltaTime;
            }
            else
            {
                if (Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < range)
            {
                transform.LookAt(Playermanager.ins.playerObject.transform.position);
                toPlayer = Playermanager.ins.playerObject.transform.position - transform.position;
              /*  movement.*/transform.Translate(toPlayer.normalized * moveSpeed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < meleeRange)
                    {
                        Attack();
                        cooldown = 0;
                    }
                }

            }
            
        }
        
    }
    void Attack()
    {
        //Damage
        DamagePlayer();
        KnockBackPlayer();

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);
    }
}
