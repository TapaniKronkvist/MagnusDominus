using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    private void Start()
    {
        if (GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
    public void SpawnBoss(GameObject boss)
    {
        GameObject newBoss = Instantiate(boss);
        boss.transform.position = transform.position;
        boss.transform.rotation = transform.rotation;
    }
}
