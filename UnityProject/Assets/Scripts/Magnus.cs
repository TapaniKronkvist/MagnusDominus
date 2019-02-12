using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnus : Enemy
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
    Vector3 playeroffset;

    // Start is called before the first frame update
    public override void Start()
    {
        currentHealth = maxHealth;
        firePoint.position = new Vector3(firePoint.position.x, 2, firePoint.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Playermanager.ins.playerObject != null && Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < range)
        {
            transform.LookAt(Playermanager.ins.playerObject.transform.position + playeroffset);
            Shoot();
        }
        else if (Playermanager.ins.playerObject != null)
        {
            transform.LookAt(Playermanager.ins.playerObject.transform.position + playeroffset);
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
            for (int i = 0; i < nrOfShots; i++)
            {
                GameObject shot = Instantiate(projectilePrefab, firePoint.position, transform.rotation);
                shot.GetComponent<Arrow>().lookDir = Quaternion.Euler(0, offsetAngle * (i + 1), 0) * transform.forward;

                shot = Instantiate(projectilePrefab, firePoint.position, transform.rotation);
                shot.GetComponent<Arrow>().lookDir = Quaternion.Euler(0, -offsetAngle * (i + 1), 0) * transform.forward;
            }
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
