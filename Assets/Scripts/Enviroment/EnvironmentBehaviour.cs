using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBehaviour : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EnvironmentSpawner environmentSpawner;
    
    [Header("Stats")]
    [SerializeField] float moveSpeed;
    [SerializeField] float lifeSpan;
    [SerializeField] private float ageThreshold;

    [Header("Booleans")]
    [SerializeField] bool cannotHitTree;
    [SerializeField] bool cannotHitBush;
    [SerializeField] bool cannotHitRock;
    [SerializeField] bool cannotHitSquiggle;
    [SerializeField] bool cannotHitWater;

    private float age;

    void FixedUpdate()
    {
        Move();
        Despawn();
    }

    void Move()
    {
        transform.position += Vector3.down * moveSpeed;
    }
    
    void Despawn()
    {
        age += Time.deltaTime;

        if (age >= lifeSpan)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        DestroyOnCollisionWithOther(col);
    }

    private void DestroyOnCollisionWithOther(Collider2D col)
    {
        var collideWithOtherTree = gameObject.HasTag("Tree") && col.gameObject.HasTag("Tree") && cannotHitTree && age <= environmentSpawner.GetSpawnCooldown() + ageThreshold;
        var collideWithOtherBush = gameObject.HasTag("Bush") && col.gameObject.HasTag("Bush") && cannotHitBush && age <= environmentSpawner.GetSpawnCooldown() + ageThreshold;
        var collideWithOtherRock = gameObject.HasTag("Rock") && col.gameObject.HasTag("Rock") && cannotHitRock && age <= environmentSpawner.GetSpawnCooldown() + ageThreshold;
        var collideWithOtherSquiggle = gameObject.HasTag("Squiggle") && col.gameObject.HasTag("Squiggle") && cannotHitSquiggle && age <= environmentSpawner.GetSpawnCooldown() + ageThreshold;
        var collideWithOtherWater = gameObject.HasTag("Water") && col.gameObject.HasTag("Water") && cannotHitWater && age <= environmentSpawner.GetSpawnCooldown() + ageThreshold;

        if(collideWithOtherTree) Destroy(gameObject);
        if(collideWithOtherBush) Destroy(gameObject);
        if(collideWithOtherRock) Destroy(gameObject);
        if(collideWithOtherSquiggle) Destroy(gameObject);
        if(collideWithOtherWater) Destroy(gameObject);
    }
}