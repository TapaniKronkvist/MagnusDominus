using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is for collides in level. To hide them when game starts.
//By Tapani Kronkvist
public class MeshRenderDisable : MonoBehaviour
{
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }
}
