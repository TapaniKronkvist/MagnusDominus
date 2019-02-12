using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float timer = 0;
    [SerializeField]
    float endTimer;
    [SerializeField]
    float speed;
    [HideInInspector]
    public int damage = 1;
    [SerializeField]
    float knockback;
    [SerializeField]
    float stunTime;
    public Vector3 lookDir;
    public Transform shooter { set { lookDir = value.forward; } }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public virtual void Update()
    {
       // gameObject.transform.Translate(transform.forward * speed * Time.deltaTime);
        if (lookDir != null)
        {
            GetComponent<Rigidbody>().velocity = lookDir * speed;
        }

        timer += Time.deltaTime;
        if (timer >= endTimer)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Coliided");
        if (collision.gameObject.CompareTag("Player"))
        {
            Damage();
            
        }
        Destroy(gameObject);
    }
    void Damage()
    {
        Playermanager.ins.DamagePlayer(damage);

        Playermanager.ins.playerObject.GetComponent<PlayerMovement>().KnockBackPlayer(knockback, transform.position);
        Playermanager.ins.playerObject.GetComponent<PlayerMovement>().StunPlayer(stunTime);

        Playermanager.ins.playerObject.GetComponent<PlayerMovement>().KnockBackPlayer(15, transform.position);
        Playermanager.ins.playerObject.GetComponent<PlayerMovement>().StunPlayer(.4f);

    }
}
