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
    [SerializeField]
    int damage;
    [SerializeField]
    float knockback;
    public Vector3 lookDir;
    public Transform shooter { set { lookDir = value.forward; } }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
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
    }
    void Damage()
    {
        Playermanager.ins.DamagePlayer(damage);
    }
}
