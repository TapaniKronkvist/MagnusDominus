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
        //Vector3 tarPos = 

        if (smooth)
        {
            transform.position =    Vector3.Lerp(transform.position,objToFollow.transform.localPosition + offset, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = objToFollow.transform.localPosition + offset;
        }
    }

    private void OnDrawGizmosSelected()
    {
       // Vector3 offseetAdj = offset * transform.forward;

        Gizmos.DrawWireSphere(objToFollow.transform.localPosition +  offset, .5f);
    }
}
