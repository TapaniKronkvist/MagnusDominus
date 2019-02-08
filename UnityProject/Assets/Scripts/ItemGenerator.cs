using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //[SerializeField]
    //List<Pickup> items = new List<Pickup>();
    public static ItemGenerator ins;
    [HideInInspector]
    public List<Pickup> itemsInWorld = new List<Pickup>();
    ItemSpawner[] itemSpawners;

#if UNITY_EDITOR
    [SerializeField]
    List<Pickup> testItems;

    public void TestSpawnItems()
    {
        SpawnItems(testItems);
    }
#endif


    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.O))
        {
            RedoItems();
            SpawnItems(testItems);
        }
#endif
    }


    private void Start()
    {
        if (ins == null) ins = this; else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void SpawnItems(List<Pickup> items)
    {
        itemSpawners = GameObject.FindObjectsOfType<ItemSpawner>();
        List<Pickup> itemsToSpawn = new List<Pickup>(items);
        for (int i = 0; i < itemSpawners.Length; i++)
        {
            if (itemsToSpawn.Count > 0)
            {
                int random = Random.Range(0, itemsToSpawn.Count - 1);
                Pickup itemToSpawn = itemsToSpawn[random];
                itemSpawners[i].SpawnItem(itemToSpawn);
                itemsToSpawn.RemoveAt(random);
            }
            else itemSpawners[i].gameObject.SetActive(false);
        }

    }

#if UNITY_EDITOR
    public void RedoItems()
    {
        if (itemSpawners != null)
        {
            for (int i = 0; i < itemSpawners.Length; i++)
            {
                itemSpawners[i].gameObject.SetActive(true);

            }

            Item[] itemsInWorld = FindObjectsOfType<Item>();
            for (int i = 0; i < itemsInWorld.Length; i++)
            {
                DestroyImmediate(itemsInWorld[i].gameObject);
            }
        }
    }

#endif

}
