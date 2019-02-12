using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected float range;
    [SerializeField]
    protected GameObject arrowPrefab;
    [SerializeField]
    protected float cooldownMax;
    protected float cooldown;
    protected Vector3 toPlayer;
    [SerializeField]
    protected Transform movement;

    [SerializeField]
    protected Vector3 bulletOffset;

    [SerializeField]
   protected int projectileDamage;
    protected virtual void Update()
    {

        if (Playermanager.ins.playerObject != null && Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < range)
        {
            if (Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) > range / 2)
            {
                transform.LookAt(Playermanager.ins.playerObject.transform.position);
                /*movement.*/transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
                Shoot();

            }
            else if(Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) <= range / 2)
            {
                transform.LookAt(Playermanager.ins.playerObject.transform.position);
             /*   movement.*/transform.Translate(transform.forward * moveSpeed * Time.deltaTime * -1);
                Shoot();
            }
        }
        if(cooldown <= cooldownMax)
        {
            cooldown += Time.deltaTime;
        }
    }
    protected virtual void Shoot()
    {
        if (cooldown >= cooldownMax)
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position + bulletOffset, transform.rotation) ;
            arrow.GetComponent<Arrow>().shooter = transform;
            arrow.GetComponent<Arrow>().damage = projectileDamage;
            cooldown = 0;
        }
            
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Coliided");
        if (collision.gameObject.CompareTag("Player"))
        {
            //  Debug.Log("Was player");
            DamagePlayer();
            KnockBackPlayer();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

