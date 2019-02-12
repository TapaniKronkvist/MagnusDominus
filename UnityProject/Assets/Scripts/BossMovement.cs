using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    [SerializeField]
    Midboss midboss;
    [SerializeField]
    Waypoints waypoints;
    Vector3 toTarget;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        FindTarget();
    }

    // Update is called once per frame
    void Update()

    {
        if (Playermanager.ins.playerObject != null && Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < midboss.range * 2)
        {
            toTarget = target.position - transform.position;
            transform.Translate(toTarget.normalized * midboss.moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                FindTarget();
            }
        }
    }
    void FindTarget()
    {
        int random = Random.Range(0, waypoints.points.Length);
        target = waypoints.points[random];
    }
}
