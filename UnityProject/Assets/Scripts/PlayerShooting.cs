using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    Transform projectileOrigin;
    [SerializeField]
    Animator circle;


    [SerializeField]
    GameObject book;
    Animator bookAnimatior;
    Playermanager pm;
    private void Start()
    {
        pm = Playermanager.ins;
        bookAnimatior = book.GetComponent<Animator>();
        
    }

    float shootTimer = -1;
    private void Update()
    {
        if (pm.aimXAxis != 0 || pm.aimYAxis != 0)
        {
            Shoot();
        }
        else { book.GetComponent<Animator>().SetBool("open", false);
            circle.SetBool("shooting", false);
        }
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
         //   Debug.Log(time);
        }

    }

    void Shoot()
    {
        if (bookAnimatior != null && !bookAnimatior.GetBool("open"))
        {
     
            bookAnimatior.SetBool("open", true);
            circle.SetBool("shooting", true);
        }
        if (shootTimer <= 0)
        {
          PlayerProjectile newProj = Instantiate(pm.CurrentPlayerProjectie.gameObject).GetComponent<PlayerProjectile>();
            newProj.transform.position = projectileOrigin.position;
            //GetComponent<AudioSource>().Play();
            //newProj.damage = pm.currentDamage;
           // Debug.Log("shut");
            shootTimer = pm.TimeBetweenShots;
        }
    }


}
