using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speedDivider;
    private Transform playerPos;

    private void Awake()
    {
        playerPos = player.transform;
    }

    private void FixedUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        var wantedPosition = new Vector3(playerPos.position.x / speedDivider, playerPos.position.y / speedDivider, -10);
        transform.position = wantedPosition;
    }
}
