using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[Range(0, 10)]
    //[SerializeField]
    //int minNumberOfEnemies;
    //[Range(0, 10)]
    //[SerializeField]
    //int maxNumberOfEnemies = 10;
    //[SerializeField]
    float spawnRadius;


    [SerializeField]
    List<Enemy> testEnemies;

    private void Start()
    {
        if (GetComponent<MeshRenderer>()) { GetComponent<MeshRenderer>().enabled = false; }



        //Enemy[] enemies = new Enemy[1];
        //SpawnEnemies(enemies);
    }
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Spawning");
            SpawnEnemies(testEnemies);
        }
#endif
    }
    public void SpawnEnemies(List<Enemy> enemiesToSpawn)
    {
        //int numberOfEnemiesToSpawn = Random.Range(minNumberOfEnemies, maxNumberOfEnemies);
     //   Debug.Log("spawning " + enemiesToSpawn.Count + " enemies");
        for (int i = 0; i < enemiesToSpawn.Count; i++)
        {
            Debug.Log("Spawning " + enemiesToSpawn[i].name);
            GameObject newEnemy = Instantiate(enemiesToSpawn[i].gameObject);
            newEnemy.transform.position = new Vector3(transform.position.x + Random.Range(-spawnRadius, spawnRadius), transform.position.y, transform.position.z + Random.Range(-spawnRadius, spawnRadius));
            Debug.Log("Spawned " + enemiesToSpawn[i].name);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.Contains(gameObject))
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    }

#endif
}
