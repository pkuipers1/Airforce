using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speedDivider;
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.Find("TestObject");// TODO: dit moet veranderd worden naar de goed speler of speler tag
    }

    private void FixedUpdate()
    {
        var playerPos = _player.transform.position;
        var wantedPosition = new Vector3(playerPos.x / speedDivider, playerPos.y / speedDivider, -10);
        transform.position = wantedPosition;
    }
}
