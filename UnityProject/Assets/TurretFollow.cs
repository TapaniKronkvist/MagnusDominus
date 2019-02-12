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
        if (objToFollow == null) { Destroy(gameObject); return; }
        else
        {
            Vector3 offseetAdj = Quaternion.Euler(0, objToFollow.transform.eulerAngles.y, 0) * offset;
            if (smooth)
            {

                transform.position = Vector3.Lerp(transform.position, objToFollow.transform.position + offseetAdj, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = objToFollow.transform.position + offseetAdj;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 offseetAdj = Quaternion.Euler(0, objToFollow.transform.eulerAngles.y, 0) * offset;
        
        Gizmos.DrawWireSphere(objToFollow.transform.position +  offseetAdj, .5f);
    }
}
