using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBlob : MonoBehaviour
{
    Vector3 toPlayer;
    [SerializeField]
    BlobEnemy blob;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Playermanager.ins.playerObject != null && Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < blob.range)
        {
            toPlayer = Playermanager.ins.playerObject.transform.position - transform.position;
            transform.Translate(toPlayer.normalized * blob.moveSpeed * Time.deltaTime);
        }
    }
}
