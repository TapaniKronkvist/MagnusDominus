using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    [SerializeField]
    float bombTimer = 10, timeBetweenBombs = 2;
    float timeLeft;
    [SerializeField]
    int bombDamage = 1;
    [SerializeField]
    TimedBomb bomb;
    public bool shouldDrop = true;
    private void Start()
    {
        timeLeft = bombTimer;
    }

    private void Update()
    {if (shouldDrop)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                timeLeft = timeBetweenBombs;

                TimedBomb newBomb = Instantiate(bomb, transform.position,Quaternion.Euler(0,0,0));
                newBomb.StartCountDown(bombTimer, bombDamage);
            }
        }
    }

}
