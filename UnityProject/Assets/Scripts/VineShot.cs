using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineShot : Arrow
{

    GameObject playerObject;
    Playermanager pm;
    Rigidbody rb;
    [SerializeField]
    float moveSpeed, lifeTime, startSpeed;

    bool strtSpd = false;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeTime);
    }

    public override void Update()
    {
        if (lookDir != Vector3.zero && !strtSpd)
        {
            Debug.Log(";)");
            strtSpd = true;
            rb.velocity = startSpeed * lookDir;
        }
        else Debug.Log("No ;)");
        if (pm == null) pm = Playermanager.ins;
        if (playerObject == null)
        {
            playerObject = pm.playerObject;
        }
        else
        {
            Vector3 dirToPlayer = (playerObject.transform.position - transform.position).normalized;
            rb.velocity += moveSpeed * Time.deltaTime * dirToPlayer;
            transform.position = new Vector3(transform.position.x, playerObject.transform.position.y, transform.position.z);
        }
    }


}
