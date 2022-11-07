using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBehaviour : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float moveSpeed;
    [SerializeField] float lifeSpan;
    [SerializeField] private float ageThreshold;

    [Header("Despawn when Touching:")] 
    [SerializeField] bool tree;
    [SerializeField] bool bush;
    [SerializeField] bool rock;
    [SerializeField] bool squiggle;
    [SerializeField] bool water;

    private float age;

    // Update is called once per frame
    void Update()
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
        if (CompareTag("Tree") && col.CompareTag("Tree") && tree)
        {
            if (age <= EnvironmentSpawner.spawnCooldown + ageThreshold)
            {
                Destroy(gameObject);
            }
        }
        if (CompareTag("Bush") && col.CompareTag("Bush") && bush)
        {
            if (age <= EnvironmentSpawner.spawnCooldown + ageThreshold)
            {
                Destroy(gameObject);
            }        
        }
        if (CompareTag("Rock") && col.CompareTag("Rock") && rock)
        {
            if (age <= EnvironmentSpawner.spawnCooldown + ageThreshold)
            {
                Destroy(gameObject);
            }        
        }
        if (CompareTag("Squiggle") && col.CompareTag("Squiggle") && squiggle)
        {
            if (age <= EnvironmentSpawner.spawnCooldown + ageThreshold)
            {
                Destroy(gameObject);
            }        
        }
        if (CompareTag("Water") && col.CompareTag("Water") && water)
        {
            if (age <= EnvironmentSpawner.spawnCooldown + ageThreshold)
            {
                Destroy(gameObject);
            }
        }
    }
}
