using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speedDivider;

    private void FixedUpdate()
    {
        var playerPos = player.transform.position;
        var wantedPosition = new Vector3(playerPos.x / speedDivider, playerPos.y / speedDivider, -10);
        transform.position = wantedPosition;
    }
}
