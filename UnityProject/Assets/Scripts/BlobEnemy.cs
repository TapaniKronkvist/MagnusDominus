using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobEnemy : Enemy
{
    [SerializeField]
    float moveSpeed;
    private void Update()
    {

        if (Playermanager.ins.playerObject != null)
        {
            transform.LookAt(Playermanager.ins.playerObject.transform.position);
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
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

}
