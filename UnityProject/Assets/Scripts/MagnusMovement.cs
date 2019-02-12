using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusMovement : MonoBehaviour
{
    [SerializeField]
    Magnus magnus;
    Vector3 toPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Playermanager.ins.playerObject != null)
        {
            toPlayer = Playermanager.ins.playerObject.transform.position - transform.position;
            transform.Translate(toPlayer.normalized * magnus.moveSpeed * Time.deltaTime);
        }
    }
}
