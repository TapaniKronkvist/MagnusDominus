using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadedScript : MonoBehaviour
{
    [SerializeField]
    bool dungeon = false;
    void Start()
    {
        if (dungeon)
        {
            WorldManager.ins.DungeonLoaded();
        }
        else
            WorldManager.ins.OverworldLoaded();


        Destroy(gameObject);
    }

}
