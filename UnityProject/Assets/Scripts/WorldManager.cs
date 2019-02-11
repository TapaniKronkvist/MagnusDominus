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

    public List<Bosses> DefeatedBosses { get => defeatedBosses; }

    [SerializeField]
    WorldState[] dungeonStates = new WorldState[3] { new WorldState("Fire Dungeon"), new WorldState("Nature Dungeon"), new WorldState("Stone Dungeon") };

    [SerializeField]
    WorldState[] overWorldStates = new WorldState[4] { new WorldState("neutral"), new WorldState("fire"), new WorldState("nature"), new WorldState("stone") };

    [SerializeField]
    int overworldSceneNum, dungeonSceneNum;

    void Start()
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

    public void DungeonLoaded()
    {

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
        if (defeatedBosses.Count > 0)
        {
            switch (defeatedBosses[defeatedBosses.Count - 1])
            {
                case Bosses.fire:
                    ItemGenerator.ins.SpawnItems(overWorldStates[1].ItemDropTable);
                    break;
                case Bosses.nature:
                    ItemGenerator.ins.SpawnItems(overWorldStates[2].ItemDropTable);
                    break;
                case Bosses.stone:
                    ItemGenerator.ins.SpawnItems(overWorldStates[3].ItemDropTable);
                    break;

            }
        }
        else
        {
            ItemGenerator.ins.SpawnItems(overWorldStates[0].ItemDropTable);
        }
    }

    void SetupOverWorldEnemies()
    {
        EnemyGenerator eg = EnemyGenerator.ins;
        if (eg == null) return;
        if (defeatedBosses.Count > 0)
        {
            switch (defeatedBosses[defeatedBosses.Count - 1])
            {
                case Bosses.fire:
                    eg.SpawnEnemies(overWorldStates[1].EnemyGroups);
                    break;
                case Bosses.nature:
                    eg.SpawnEnemies(overWorldStates[2].EnemyGroups);
                    break;
                case Bosses.stone:
                    eg.SpawnEnemies(overWorldStates[3].EnemyGroups);
                    break;
            }
        }
        else
        {
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
    List<Pickup> itemDropTable = new List<Pickup>();
    public List<Pickup> ItemDropTable { get => itemDropTable; }

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