using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
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
