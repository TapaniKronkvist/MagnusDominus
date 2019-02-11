using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    [SerializeField]
    List<GroupOfEnemies> testGroups;
    public static EnemyGenerator ins;

    private void Start()
    {
        if (EnemyGenerator.ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnEnemies(testGroups);
        }
#endif
    }

    EnemySpawner[] FindSpawners()
    {
        EnemySpawner[] spawners = GameObject.FindObjectsOfType<EnemySpawner>();
        return spawners;

    }

    public void SpawnEnemies(List<GroupOfEnemies> enemies)
    {
        EnemySpawner[] spawners = FindSpawners();
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].SpawnEnemies(enemies[Random.Range(0,enemies.Count)].enemies);
        }
    }

}
