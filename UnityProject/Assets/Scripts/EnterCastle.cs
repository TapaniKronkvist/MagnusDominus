using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCastle : MonoBehaviour
{

    [SerializeField]
    WorldManager.Bosses castleToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WorldManager.ins.LoadDungeon(castleToLoad);
        }
    }
}
