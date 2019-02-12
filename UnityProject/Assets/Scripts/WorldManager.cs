using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    public static WorldManager ins;
    // Start is called before the first frame update
    public enum Bosses { fire, nature, stone }
    List<Bosses> defeatedBosses = new List<Bosses>();
    Bosses stateToLoad;
    public List<Bosses> DefeatedBosses { get => defeatedBosses; }
    [SerializeField]
    GameObject fireBoss, natureBoss, stoneBoss, magnusBoss;
    [SerializeField]
    WorldState[] dungeonStates = new WorldState[3] { new WorldState("Fire Dungeon"), new WorldState("Nature Dungeon"), new WorldState("Stone Dungeon") };

    [SerializeField]
    WorldState[] overWorldStates = new WorldState[4] { new WorldState("neutral"), new WorldState("fire"), new WorldState("nature"), new WorldState("stone") };

    [SerializeField]
    int overworldSceneNum, dungeonSceneNum;

    void Awake()
    {
        if (WorldManager.ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }


    public void LoadOverWorld()
    {

        SceneManager.LoadScene(overworldSceneNum);
    }
    public void LoadDungeon(Bosses state)
    {
        SceneManager.LoadScene(dungeonSceneNum);
        stateToLoad = state;
    }
    public void DungeonLoaded()
    {
        SetupDungeonEnemies();
        SetupDungeonItems();
    }

    void SetupDungeonItems()
    {
        switch (stateToLoad)
        {
            case Bosses.fire:
                ItemGenerator.ins.SpawnItems(WorldManager.ins.dungeonStates[0].itemDropTable);
                break;
            case Bosses.nature:
                ItemGenerator.ins.SpawnItems(WorldManager.ins.dungeonStates[1].itemDropTable);
                break;
            case Bosses.stone:
                ItemGenerator.ins.SpawnItems(WorldManager.ins.dungeonStates[2].itemDropTable);
                break;
            default:
                break;
        }
    }
    void SetupDungeonEnemies()
    {
        switch (stateToLoad)
        {
            case Bosses.fire:
                Debug.Log("Spawning fire enemies");
                EnemyGenerator.ins.SpawnEnemies(WorldManager.ins.dungeonStates[0].EnemyGroups);
                if (FindObjectOfType<BossSpawner>())
                {
                    FindObjectOfType<BossSpawner>().SpawnBoss(fireBoss);
                }
                break;
            case Bosses.nature:
                Debug.Log("Spawning nature enemies");
                EnemyGenerator.ins.SpawnEnemies(WorldManager.ins.dungeonStates[1].EnemyGroups);
                if (FindObjectOfType<BossSpawner>())
                {
                    FindObjectOfType<BossSpawner>().SpawnBoss(natureBoss);
                }
                break;
            case Bosses.stone:
                Debug.Log("Spawning stone enemies");
                EnemyGenerator.ins.SpawnEnemies(WorldManager.ins.dungeonStates[2].EnemyGroups);
                if (FindObjectOfType<BossSpawner>())
                {
                    FindObjectOfType<BossSpawner>().SpawnBoss(stoneBoss);
                }
                break;
            default:
                break;
        }
    }

    public void OverworldLoaded()
    {
        SetupOverWorldEnemies();
        SetupOverWorldItems();
    }


    private void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKey(KeyCode.Y))
        {
            DefeatBoss(Bosses.fire);
        }
#endif
    }

    public void DefeatBoss(Bosses boss)
    {
        defeatedBosses.Add(boss);
        LoadOverWorld();
    }

    void SetupOverWorldItems()
    {
        Debug.Log("Items");
        if (defeatedBosses.Count > 0)
        {
            
            switch (defeatedBosses[defeatedBosses.Count - 1])
            {
                case Bosses.fire:
                    Debug.Log("Spawning fire items");
                    ItemGenerator.ins.SpawnItems(overWorldStates[1].itemDropTable);

                    break;
                case Bosses.nature:
                    Debug.Log("Spawning nature items");
                    ItemGenerator.ins.SpawnItems(overWorldStates[2].itemDropTable);
                    break;
                case Bosses.stone:
                    Debug.Log("Spawning stone items");
                    ItemGenerator.ins.SpawnItems(overWorldStates[3].itemDropTable);
                    break;

            }
        }
        else
        {
            ItemGenerator.ins.SpawnItems(overWorldStates[0].itemDropTable);
        }
    }

    void SetupOverWorldEnemies()
    {
        Debug.Log("Spawning");
        EnemyGenerator eg = EnemyGenerator.ins;
        if (eg == null) return;
        if (defeatedBosses.Count > 0)
        {
            switch (defeatedBosses[defeatedBosses.Count - 1])
            {
                case Bosses.fire:
                    Debug.Log("Spawning fire enemies");
                    eg.SpawnEnemies(overWorldStates[1].EnemyGroups);
                    break;
                case Bosses.nature:
                    Debug.Log("Spawning nature enemies");
                    eg.SpawnEnemies(overWorldStates[2].EnemyGroups);
                    break;
                case Bosses.stone:
                    Debug.Log("Spawning stone enemies");
                    eg.SpawnEnemies(overWorldStates[3].EnemyGroups);
                    break;
            }
        }
        else
        {
            Debug.Log("Spawning neutral");
            eg.SpawnEnemies(overWorldStates[0].EnemyGroups);
        }
    }


}


[System.Serializable]
public class WorldState
{

    public WorldState(string name)
    {
        this.name = name;
    }
    [HideInInspector]
    public string name;
    [SerializeField]
    public List<Pickup> itemDropTable = new List<Pickup>();
  //  public List<Pickup> ItemDropTable { get => itemDropTable; }

    [SerializeField]
    List<GroupOfEnemies> enemyGroups = new List<GroupOfEnemies>();
    //public GroupOfEnemies[] EnemyGroups { get => enemyGroups.ToArray(); }
    public List<GroupOfEnemies> EnemyGroups { get => enemyGroups; }
}
[System.Serializable]
public class GroupOfEnemies
{

    //    [HideInInspector]
    public string name;
    [SerializeField]
    public List<Enemy> enemies = new List<Enemy>();


}