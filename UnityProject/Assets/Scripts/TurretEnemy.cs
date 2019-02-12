using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Enemy
{
    [SerializeField]
   protected float range, rotSpd;
    Playermanager pm;
    [SerializeField]
    GameObject barrel;
    [SerializeField]
    protected GameObject bulletExitPoint;

    protected bool hasTarget;

    public override void Start()
    {
        base.Start();
        pm = Playermanager.ins;
    }
    public virtual void FixedUpdate()
    {
        TargetPlayer();
        if (hasTarget) Shoot();
    }

    public virtual void Shoot()
    {
        GameObject newBull = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        newBull.AddComponent<Rigidbody>();
        newBull.transform.position = bulletExitPoint.transform.position;
        newBull.GetComponent<Rigidbody>().mass = 50;
    }

    public virtual void TargetPlayer()
    {
        if (pm.playerObject != null && Vector3.Distance(transform.position, pm.playerObject.transform.position) <= range)
        {
            // Debug.Log("IN RANGE");
            Quaternion playerDir = Quaternion.LookRotation(pm.playerObject.transform.position - barrel.transform.position);
            barrel.transform.rotation = Quaternion.Slerp(barrel.transform.rotation, playerDir, rotSpd * Time.deltaTime);

            hasTarget = true;
        }
        else hasTarget = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
