using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float targetLocation;
    [SerializeField] private float moveSpeed;

    private float positionY;
    
    private void FixedUpdate()
    {
        positionY = transform.position.y;
        MoveToTargetLocation();
    }

    void MoveToTargetLocation()
    {
        if (positionY > targetLocation)
        {
            transform.position += Vector3.down * (moveSpeed / 10);
        }
    }
}
