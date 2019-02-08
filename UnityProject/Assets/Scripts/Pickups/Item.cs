using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [HideInInspector]
    public IPickup pickup;


    public virtual void CreateWorldViz()
    {
        GameObject newObj = Instantiate(pickup.WorldObject, transform);
        newObj.transform.position = transform.position; 
        if (GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickUp();
        }
    }

    public virtual void PickUp()
    {
        Destroy(gameObject);
    }


}
