using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour, IDamageable
{
    [SerializeField]
    float lifetime = 1;
    [SerializeField]
    GameObject destroyedSelf;
    GameObject destObj;
    private void Start()
    {
        if (destroyedSelf != null)
        {
            destObj = Instantiate(destroyedSelf);
            destObj.SetActive(false);
            destObj.transform.parent = transform;
        }
    }


    public void Damage(float d, GameObject s)
    {
        if (destObj != null)
        {
            destObj.transform.parent = transform.parent;
            destObj.transform.position = transform.position;
            destObj.transform.localRotation = transform.localRotation;
            destObj.SetActive(true);
            if (destObj.GetComponent<DestructibleObjectDebree>())
            {
                destObj.GetComponent<DestructibleObjectDebree>().DestroyMe(lifetime);
            }

        }


        Destroy(gameObject);
    }
}
