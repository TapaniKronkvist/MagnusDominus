using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObjectDebree : MonoBehaviour
{

    public void DestroyMe(float lifetime)
    {
        Destroy(gameObject, lifetime);
    }

}
