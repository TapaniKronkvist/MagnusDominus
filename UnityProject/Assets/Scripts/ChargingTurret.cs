using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingTurret : TurretEnemy
{
    [SerializeField]
    ParticleSystem chargeEffect, hitEffect, shootEffect;
    [SerializeField]
    Light endLight, startLight;
    bool charged = false;
    bool charging = false;
    [SerializeField]
    float chargeTime = 1f, postShootWait = 1, shootTime = 1, beamMoveSpeed;
    float waitTimeLeft, shootTimeLeft;
    [SerializeField]
    LayerMask mask;
    float chargeTimeLeft;
    [SerializeField]
    int projectiles;
    int projectilesLeft;

    [SerializeField]
    LineRenderer beam;

    public override void Start()
    {
        base.Start();
        beam.gameObject.SetActive(false);
    }
    public override void FixedUpdate()
    {
        //        base.FixedUpdate();
        TargetPlayer();
        Shoot();
        if (charging)
        {
            Charge();
        }


    }

    public override void Shoot()
    {
        Debug.Log("Shoot");
        beam.SetPosition(0, bulletExitPoint.transform.position);
        //  base.Shoot();
        if (!charged && !charging && waitTimeLeft <= 0 && hasTarget)
        {
            BeginCharging();

        }
        else if (shootTimeLeft > 0 && hasTarget)
        {
            //GameObject newbull = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere));
            //newbull.transform.position = bulletExitPoint.transform.position;
            //newbull.AddComponent<Rigidbody>(); projectilesLeft--;
            beam.SetPosition(0, bulletExitPoint.transform.position);
            shootTimeLeft -= Time.deltaTime;

            RaycastHit hit;
            if (Physics.Raycast(bulletExitPoint.transform.position, bulletExitPoint.transform.forward, out hit, Mathf.Infinity,mask ))
            {
                beam.SetPosition(1, Vector3.Lerp(beam.GetPosition(1), hit.point, beamMoveSpeed * Time.deltaTime));
                beam.gameObject.SetActive(true);

                hitEffect.transform.position = hit.point;
                hitEffect.transform.rotation = Quaternion.LookRotation(hit.normal);
                hitEffect.Play();
                shootEffect.Play();
                startLight.enabled = true;
                endLight.enabled = true;

                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    DamagePlayer();
                }
                else if (hit.collider.GetComponent<IDamageable>() != null && !hit.collider.gameObject.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<IDamageable>().Damage(damage, gameObject);
                }

            } else
            {
                beam.gameObject.SetActive(false);
                hitEffect.Stop();
                startLight.enabled = false;
                endLight.enabled = false;
            }



        }
        else if (charged || !hasTarget)
        {
            charged = false;
            waitTimeLeft = postShootWait;
            beam.gameObject.SetActive(false);
            hitEffect.Stop();
            startLight.enabled = false;
            endLight.enabled = false;
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
            beam.SetPosition(1, bulletExitPoint.transform.position);
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
