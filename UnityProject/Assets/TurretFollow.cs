using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFollow : MonoBehaviour
{
    [SerializeField]
    GameObject objToFollow;
    [SerializeField]
    Vector3 offset;

    [SerializeField]
    bool smooth = false;
    [SerializeField]
    float moveSpeed = 10;

    private void Start()
    {
        transform.position = objToFollow.transform.position + offset;
    }

    private void FixedUpdate()
    {

        if (smooth)
        {
            transform.position =    Vector3.Lerp(transform.position,( objToFollow.transform.forward * objToFollow.transform.position.magnitude) + offset, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = objToFollow.transform.forward * objToFollow.transform.position.magnitude + offset;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(objToFollow.transform.position + offset, .5f);
    }
}
