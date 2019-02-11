using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingTurret : TurretEnemy
{
    [SerializeField]
    ParticleSystem chargeEffect, hitEffect;
    bool charged = false;
    bool charging = false;
    [SerializeField]
    float chargeTime = 1f, postShootWait = 1, shootTime = 1;
    float waitTimeLeft , shootTimeLeft;

    float chargeTimeLeft;
    [SerializeField]
    int projectiles;
    int projectilesLeft;

    [SerializeField]
    LineRenderer beam;

    public override void Start()
    {
        base.Start();

    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (charging)
        {
            Charge();
        }


    }

    public override void Shoot()
    {
        Debug.Log("Shoot");
        //  base.Shoot();
        if (!charged && !charging && waitTimeLeft <= 0)
        {
            BeginCharging();
        }
        else if (shootTimeLeft > 0)
        {
            //GameObject newbull = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere));
            //newbull.transform.position = bulletExitPoint.transform.position;
            //newbull.AddComponent<Rigidbody>(); projectilesLeft--;
            beam.SetPosition(0, bulletExitPoint.transform.position);
            shootTimeLeft -= Time.deltaTime;

            RaycastHit hit; 
            if (Physics.Raycast(bulletExitPoint.transform.position,bulletExitPoint.transform.forward, out hit, Mathf.Infinity))
            {
                beam.SetPosition(1, hit.point);
                beam.gameObject.SetActive(true);
                hitEffect.transform.position = hit.point;
                hitEffect.transform.rotation = Quaternion.LookRotation(hit.normal);
                hitEffect.Play();
            }



        }
        else if (charged)
        {
            charged = false;
            waitTimeLeft = postShootWait;
            beam.gameObject.SetActive(false);
            hitEffect.Stop();

        }
        waitTimeLeft -= Time.deltaTime;
    }

    void Charge()
    {

        chargeTimeLeft -= 1 * Time.deltaTime;
     //   Debug.Log(chargeTimeLeft);
        if (chargeTimeLeft <= 0)
        {
            shootTimeLeft = shootTime;
            projectilesLeft = projectiles;
            charged = true;
            //     chargeEffect.gameObject.SetActive(false);

            charging = false;
            Debug.Log("Done");

        }
    }

    void BeginCharging()
    {
        Debug.Log("Beginning");
        chargeTimeLeft = chargeTime;
        charging = true;
        chargeEffect.Play();

    }
}
