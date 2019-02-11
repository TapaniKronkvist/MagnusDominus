using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleGoblin : Goblin
{

    [SerializeField]
    float offset = 20;

    protected override void Shoot()
    {
        if (cooldown >= cooldownMax)
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
            arrow.GetComponent<Arrow>().shooter = transform;
            arrow.GetComponent<Arrow>().damage = projectileDamage;
            GameObject arrow2 = Instantiate(arrowPrefab, transform.position, transform.rotation);
            arrow2.GetComponent<Arrow>().lookDir = Quaternion.Euler(0, -offset, 0) * transform.forward;
            arrow2.GetComponent<Arrow>().damage = projectileDamage;
            arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
            arrow.GetComponent<Arrow>().lookDir = Quaternion.Euler(0,offset,0) * transform.forward;
            arrow.GetComponent<Arrow>().damage = projectileDamage;

            cooldown = 0;
        }
    }
}
