using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexScroller : MonoBehaviour
{[SerializeField]
    float timeX = 1 , timeY = 1;
    float offsetX = 0, offsetY = 0;
    Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        
    }
    // Update is called once per frame
    void Update()
    {
        offsetX += timeX * Time.deltaTime;
        offsetY += timeY * Time.deltaTime;
        rend.material.SetTextureOffset(Shader.PropertyToID("_MainTex"), new Vector2(offsetX, offsetY));
    }
}
