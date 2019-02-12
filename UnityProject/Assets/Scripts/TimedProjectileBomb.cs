using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedProjectileBomb : TimedBomb
{
    [SerializeField]
    Arrow projectile;
    [SerializeField]
    float numberOfProjectiles, angleOffset, bulletDelay, startOffset;

    public override void Detonation()
    {
        StartCoroutine(boom(bulletDelay));
    }


    public override void Death()
    {
        Detonation();
    }
    IEnumerator boom(float time)
    {

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            Arrow arrow = Instantiate(projectile, transform.position, Quaternion.Euler(0,0,0));
            arrow.lookDir = Quaternion.Euler(0, startOffset + (angleOffset * i) , 0)  * transform.forward;
            arrow.damage = this.damage;
            yield return new WaitForSeconds(time);
        }
        Destroy(gameObject);
    }
}
