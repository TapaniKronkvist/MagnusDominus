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
    float playerFollowXOffset = 0, playerFollowZOffset = 0, playerFollowYOffset = 0, cameraMoveTime = 0;

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
                        transform.position = Vector3.Lerp(transform.position, playerObject.transform.position + new Vector3(playerFollowXOffset, playerFollowYOffset, playerFollowZOffset), cameraMoveTime * Time.deltaTime);
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
        transform.position = playerObject.transform.position + new Vector3(playerFollowXOffset, playerFollowYOffset, playerFollowZOffset);
    }



}
