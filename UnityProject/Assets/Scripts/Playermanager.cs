using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermanager : MonoBehaviour
{

    #region PlayerStats
    [SerializeField]
    PlayerProjectile currentProjectile;
    public float currentDamage = 1;
    [SerializeField]
    float baseMovementSpeed;
    public float BaseMovementSpeed { get => baseMovementSpeed; }
    public float movementSpeedModifier = 1;
    public float projectileSpeedModifier = 1;
    [SerializeField]
    public List<Equipment> playerEquipment = new List<Equipment>();
    public enum Element { fire, stone, nature, neutral}
    public Element selectedElemen = Element.neutral;
    List<Element> unlockedElements = new List<Element>();

    [SerializeField]
    int maxHP = 1;
    int currentHP;
    public int CurrentHP { get => currentHP; }

    public int MaxHP
    {
        set
        {
            MaxHP = value;
            if (currentHP > maxHP)
            {
                currentHP = MaxHP;
            }
        }

        get { return maxHP; }
    }
    [SerializeField]
    float basePostDamageInvulTime = 1f;
    public float postDamageInvulTimeModifier = 1;

    [SerializeField]
    float baseTimeBetweenShots;

    public float BaseTimeBetweenShots { get => baseTimeBetweenShots; }
    public float TimeBetweenShots { get =>  BaseTimeBetweenShots * timeBetweenShotsModifier;  }
    public float timeBetweenShotsModifier = 1;
    public float postDamageInvulTime { get { return basePostDamageInvulTime * postDamageInvulTimeModifier; } }

    #endregion




    public float xAxis = 0, yAxis = 0, aimXAxis = 0, aimYAxis = 0;
    public GameObject playerObject;
    public static Playermanager ins;


    bool canBeDamaged = true;

    private void Awake()
    {
        Playermanager.ins = this;
        currentHP = maxHP;
        DontDestroyOnLoad(gameObject);

        playerObject = GameObject.FindGameObjectWithTag("Player");
        CalculateStats();
    }

    private void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        aimXAxis = Input.GetAxis("XrightCont") + Input.GetAxisRaw("XrightKey");
        aimYAxis = Input.GetAxis("YrightCont") + Input.GetAxisRaw("YrightKey");

        if (Input.GetKey(KeyCode.F)) { }

    }

    public void CalculateStats()
    {
        timeBetweenShotsModifier = 1;
        movementSpeedModifier = 1;
        postDamageInvulTimeModifier = 1;
        projectileSpeedModifier = 1;
        

        for (int i = 0; i < playerEquipment.Count; i++)
        {
            playerEquipment[i].ChangePlayerStats();
        }

        Debug.Log(string.Format("MaxHP: {0} CurHP: {1} TimeBetShots:{2} MoveSpeed{3}", maxHP, currentHP, TimeBetweenShots, movementSpeedModifier * baseMovementSpeed));
    }

    public void PickUpEquipment(Equipment equipment)
    {
        playerEquipment.Add(equipment);
        CalculateStats();
    }


    #region ProjectileStuff

    public PlayerProjectile CurrentPlayerProjectie
    {
        get { return currentProjectile; }
        set
        {
            currentProjectile = value;

        }
    }

    #endregion ProjectileStuff


    #region Healthstuff

    public void DamagePlayer(int amount)
    {
        if (canBeDamaged)
        {

            currentHP -= amount;

            if (currentHP <= 0)
            {
                Death();
            }
            StartCoroutine(InvulTime(postDamageInvulTime));
        }
    }

    IEnumerator InvulTime(float time)
    {
        canBeDamaged = false;
        yield return new WaitForSeconds(time);
        canBeDamaged = true;
    }

    public void Death()
    {
        Destroy(playerObject);
        Debug.Log("You Died");
    }

    public void Heal(int healAmount)
    {
        if (currentHP + healAmount <= maxHP) currentHP += healAmount; else currentHP = maxHP;
    }
    #endregion Healtstuff
}
