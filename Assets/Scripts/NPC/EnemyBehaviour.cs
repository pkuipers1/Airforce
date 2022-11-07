using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float targetLocation;
    [SerializeField] private float moveSpeed;

    private float positionY;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
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
