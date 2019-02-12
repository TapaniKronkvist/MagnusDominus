using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPBasic : PlayerProjectile
{
    [SerializeField]
    GameObject endPrefab;
    [SerializeField]
    float baseProjectileMoveSpeed = 10;
    float projectileMoveSpeed { get => Playermanager.ins.projectileSpeedModifier * baseProjectileMoveSpeed; }
    Vector3 playerSpeed;
    Vector3 lookDir;
    Rigidbody rb;
    [SerializeField]
    GameObject playerObj;
    public override void Start()
    {
        base.Start();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        lookDir = playerObj.transform.forward;
        playerSpeed = playerObj.GetComponent<Rigidbody>().velocity;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = projectileMoveSpeed * lookDir * Playermanager.ins.projectileSpeedModifier;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IDamageable>() != null)
        {
            collision.gameObject.GetComponent<IDamageable>().Damage(Damage, Playermanager.ins.gameObject);
            
        }


        GameObject newobj = Instantiate(endPrefab);
        newobj.transform.position = transform.position;
        newobj.transform.rotation = transform.rotation;
        Destroy(newobj.gameObject, 1);
        Destroy(gameObject);
//        gameObject.tag = "owo";
    }


}
