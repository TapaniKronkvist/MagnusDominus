using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    protected float currentHealth;
    [SerializeField]
    protected float maxHealth;
    [SerializeField]
    protected int damage;
    [SerializeField]
    float knockBackForce, stunTime;

    public float Health
    {
        get => currentHealth;

        set
        {
            currentHealth = value;
           // Debug.Log(value + " " + currentHealth);
            if (currentHealth <= 0)
            {
                Debug.Log("yo");
                Death();
            }
        }
    }

    public virtual void Start()
    {
        currentHealth = maxHealth;
    }


    public virtual void Damage(float d, GameObject s)
    {
     //   Debug.Log("ow");
        //Debug.Log(d + " " + currentHealth);
        Health -= d;
    }

    public virtual void Death()
    {
        Debug.Log(name + " died");
        Destroy(gameObject);
    }


    public virtual void DamagePlayer()
    {
        Playermanager.ins.DamagePlayer(damage);
    }

    public virtual void KnockBackPlayer()
    {
        Debug.Log("Enemy knockback");
        Playermanager.ins.playerObject.GetComponent<PlayerMovement>().KnockBackPlayer(knockBackForce, transform.position);
        Playermanager.ins.playerObject.GetComponent<PlayerMovement>().StunPlayer(stunTime);
    }

}
