using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This clas destroys the sfx after being played.

public class sfx : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 3);
    }
    
    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
