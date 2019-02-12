using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedBomb : MonoBehaviour, IDamageable
{
    [SerializeField]
    float health = 10;
    [SerializeField]
    bool damageable = true;
    bool started = false;
    float timeLeft;

    bool detonated = false;

    protected int damage;

    public void Damage(float damage, GameObject dmgSource)
    {
        if (damageable)
        {
            health -= damage;
            if (health <= 0)
            {
                Death();
            }
        }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (timeLeft <= 0)
            {
                if (!detonated)
                {
                    detonated = true;
                    Detonation();
                }
            }
            else timeLeft -= Time.deltaTime;
        }
    }
    public virtual void Detonation()
    {
        Destroy(gameObject);
        Debug.Log("Boom");
    }
    public virtual void StartCountDown(float time, int damage)
    {
        this.damage = damage;
        started = true;
        timeLeft = time;
    }

}
