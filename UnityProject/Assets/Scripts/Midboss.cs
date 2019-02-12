using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Midboss : Enemy
{
    public float moveSpeed;
    public float range;
    [SerializeField]
    float nrOfShots;
    [SerializeField]
    float offsetAngle;
    [SerializeField]
    GameObject projectilePrefab;
    [SerializeField]
    protected float cooldownMax;
    protected float cooldown;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    Waypoints waypoints;
    Vector3 toTarget;
    Transform target;


    public override void Start()
    {
        currentHealth = maxHealth;
        firePoint.position = new Vector3(firePoint.position.x, Playermanager.ins.playerObject.transform.position.y, firePoint.position.z);
    }

    private void Update()
    {

        if (Playermanager.ins.playerObject != null && Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < range)
        {
            firePoint.position = new Vector3(firePoint.position.x, Playermanager.ins.playerObject.transform.position.y, firePoint.position.z);
            transform.LookAt(Playermanager.ins.playerObject.transform.position);
            Shoot();
        
        }
        if (cooldown <= cooldownMax)
        {
            cooldown += Time.deltaTime;
        }
    }

    void Shoot()
    {
        if (cooldown >= cooldownMax)
        {
            GameObject shot = Instantiate(projectilePrefab, firePoint.position, transform.rotation);
            shot.GetComponent<Arrow>().shooter = transform;

            for (int i = 0; i < nrOfShots; i++)
            {
                shot = Instantiate(projectilePrefab, firePoint.position, transform.rotation);
                shot.GetComponent<Arrow>().lookDir = Quaternion.Euler(0, offsetAngle * (i + 1), 0) * transform.forward;

                shot = Instantiate(projectilePrefab, firePoint.position, transform.rotation);
                shot.GetComponent<Arrow>().lookDir = Quaternion.Euler(0, -offsetAngle * (i + 1), 0) * transform.forward;
            }
            cooldown = 0;
        }

    }

    void FindTarget()
    {
        int random = Random.Range(0, waypoints.points.Length);
        target = waypoints.points[random];
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
