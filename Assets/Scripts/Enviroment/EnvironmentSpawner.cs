using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnvironmentSpawner : MonoBehaviour
{
    [Header("Spawnable Items")]
    [SerializeField] GameObject[] environmentParts;
    
    [Header("Spawn Constraints")]
    [SerializeField] float spawnAreaXMin;
    [SerializeField] float spawnAreaXMax;
    [SerializeField] float spawnAreaY;
    [SerializeField] float spawnCooldown;
    private float currentSpawnCooldown;
    
    [Header("Random Rotation")]
    [SerializeField] bool randomRotation;
    [SerializeField] float randomRotationMin;
    [SerializeField] float randomRotationMax;
    
    [Header("Random Scale")]
    [SerializeField] bool randomScale;
    [SerializeField] float randomScaleMin;
    [SerializeField] float randomScaleMax;
    
    void Update()
    {
        currentSpawnCooldown -= Time.deltaTime;
        if (currentSpawnCooldown <= 0)
        {
            Spawn();
        }    
    }    

    void Spawn()
    {
        var rotation = 0f;
        var scale = 1f;
        
        var randomSpawnPos = Random.Range(spawnAreaXMin, spawnAreaXMax);
        var randomRot = Random.Range(randomRotationMin, randomRotationMax);
        var randomScaleFactor = Random.Range(randomScaleMin, randomScaleMax);
        
        var randomSpawnNR = Random.Range(0, environmentParts.Length);
        
        if (randomRotation) rotation = randomRot;
        if (randomScale) scale = randomScaleFactor;

        var objectMade = Instantiate(environmentParts[randomSpawnNR], new Vector2(randomSpawnPos, spawnAreaY), Quaternion.Euler(new Vector3(0, 0, rotation)));

        objectMade.transform.localScale = new Vector3(scale, scale, 1);
        objectMade.transform.SetParent(transform);
        
        currentSpawnCooldown = spawnCooldown;
    }

    public float GetSpawnCooldown() => spawnCooldown;
}
