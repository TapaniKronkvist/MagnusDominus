using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public enum cameraModes { FollowPlayer, Fixed }
    public cameraModes currentMode = cameraModes.FollowPlayer;
    [SerializeField]
    GameObject playerObject;
    [SerializeField]
    float playerFollowXOffset = 0, playerFollowZOffset = 0, playerFollowYOffset = 0, cameraMoveTime = 0, aimMove = 5;
 public   float cameraRotation = 45;
    private void Start()
    {
        if (playerObject == null)
        {
            playerObject = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void FixedUpdate()
    {
        if (playerObject != null)
        {
            switch (currentMode)
            {
                case cameraModes.FollowPlayer:
                    if (playerObject != null)
                    {
                        if (transform.eulerAngles.y != 45)
                        {
                            transform.rotation = Quaternion.Euler( new Vector3(transform.eulerAngles.x, cameraRotation, transform.eulerAngles.z));
                         //   Debug.Log("Correcting y rotation");
                        }

                        transform.position = Vector3.Lerp(transform.position, playerObject.transform.position + Quaternion.Euler(0, cameraRotation, 0) * new Vector3(playerFollowXOffset + aimMove * Playermanager.ins.aimXAxis, playerFollowYOffset, playerFollowZOffset + Playermanager.ins.aimYAxis * aimMove) , cameraMoveTime * Time.deltaTime);
                    }
                    break;
                case cameraModes.Fixed:
                    break;
                default:
                    break;
            }

        }
    }

    public void UpdatePos() {

        if (playerObject != null)
        {
            transform.position = playerObject.transform.position + Quaternion.Euler(0, cameraRotation, 0) * new Vector3(playerFollowXOffset, playerFollowYOffset, playerFollowZOffset);
        }
        else Debug.Log("PlayerObject not set");
    }



}
