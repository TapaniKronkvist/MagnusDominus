using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float Damage
    {
        get
        {
      //      Debug.Log(Playermanager.ins.currentDamage);
            return Playermanager.ins.currentDamage;
        }
    }
    [SerializeField]
    public float lifeTime = 1;

    public virtual void DealDamage(IDamageable target )
    {
        target.Damage(Damage, Playermanager.ins.gameObject);
    }
    public virtual void Start()
    {
        Destroy(gameObject, lifeTime);
    }


}
