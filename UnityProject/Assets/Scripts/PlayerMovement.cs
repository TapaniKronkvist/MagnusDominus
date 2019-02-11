using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 movDir;
    [SerializeField]
    Playermanager pm;
    float xAxis = 0, yAxis = 0, aimXAxis = 0, aimYAxis = 0;
    [SerializeField]
    public float baseMovementSpeed { get { return pm.BaseMovementSpeed; } }
    [SerializeField]
    bool canMove = true, canAim = true;
    float currentMoveSpeed;
    [SerializeField]
    float speedModifier { get { return pm.movementSpeedModifier; } }
    float aimAngle;
    bool recentlyAimed;
    [SerializeField]
    float aimWaitTime = 1;
    [SerializeField]
    Rigidbody rb;
    Vector2 moveDirection;
    public Vector2 PlayerMoveDirection { get => moveDirection; }
    public float cameraRotation = 45;

    // Start is called before the first frame update
    void Start()
    {
        if (Playermanager.ins != null)
        {
            pm = Playermanager.ins;
        }
        if (pm == null)
        {
            Destroy(gameObject);
            Debug.Log("No pm");
        }
        if (rb == null)
            rb = GetComponent<Rigidbody>();
        calcMoveSpeed();

    }


    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = pm.xAxis;
        yAxis = pm.yAxis;
        aimXAxis = pm.aimXAxis;
        aimYAxis = pm.aimYAxis;
        MovePlayer();
        movDir = rb.velocity.normalized;
        AimPlayer();
        //Debug.Log(string.Format("XW: {0} YW: {1} XA: {2} YA: {3}", xAxis, yAxis, aimXAxis, aimYAxis));

    }


    public void MovePlayer()
    {
        if (canMove)
        {
            calcMoveSpeed();
            moveDirection = new Vector2(xAxis, yAxis).normalized;
            rb.velocity = Quaternion.Euler(0, cameraRotation, 0) * new Vector3(currentMoveSpeed * moveDirection.x, rb.velocity.y, currentMoveSpeed * moveDirection.y);


        }
    }


    public void KnockBackPlayer(float force, Vector3 originPoint)
    {
        Vector3 dirToOr = (transform.position - originPoint).normalized;
        rb.velocity = dirToOr * force;
    }

    public void StunPlayer(float t)
    {
        StartCoroutine(StunPlayerCo(t));
    }

    IEnumerator StunPlayerCo(float t)
    {
        canMove = false;
        yield return new WaitForSeconds(t);
        canMove = true;
    }

    void AimPlayer()
    {
        if (canAim)
        {
            if (aimYAxis != 0 || aimXAxis != 0)
            {
                aimAngle = Mathf.Atan2(aimXAxis, aimYAxis) * 180 / Mathf.PI;
                recentlyAimed = true;
                StartCoroutine("aimWait");

            }
            else if (xAxis != 0 && !recentlyAimed || yAxis != 0 && !recentlyAimed)
            {
                aimAngle = Mathf.Atan2(xAxis, yAxis) * 180 / Mathf.PI;
            }


        }


        //  Debug.Log("k");
        transform.eulerAngles = new Vector3(0, aimAngle+cameraRotation, 0);

    }


    IEnumerator aimWait()
    {
        //Debug.Log("Waiting");
        yield return new WaitForSeconds(aimWaitTime);
        recentlyAimed = false;
    }


    void calcMoveSpeed()
    {
        currentMoveSpeed = baseMovementSpeed * speedModifier;
        //Debug.Log(currentMoveSpeed);
    }


}
