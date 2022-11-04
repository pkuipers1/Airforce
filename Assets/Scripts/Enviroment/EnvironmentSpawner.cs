using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnvironmentSpawner : MonoBehaviour
{
    [Header("Spawnable Items:")]
    public GameObject[] environmentParts;
    
    [Header("Spawn Constraints:")]
    public float spawnAreaXMin;
    public float spawnAreaXMax;
    public float spawnAreaY;
    public float spawnCooldown;
    private float currentSpawnCooldown;
    
    [Header("Random Rotation:")]
    public bool randomRotation;
    public float randomRotationMin;
    public float randomRotationMax;
    
    [Header("Random Scale:")]
    public bool randomScale;
    public float randomScaleMin;
    public float randomScaleMax;
    
    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        currentSpawnCooldown -= Time.deltaTime;

        if (currentSpawnCooldown <= 0)
        {
            var rotation = 0f;
            var scale = 1f;
            
            float randomSpawnPos = Random.Range(spawnAreaXMin, spawnAreaXMax);
            float randomRot = Random.Range(randomRotationMin, randomRotationMax);
            float randomScaleFactor = Random.Range(randomScaleMin, randomScaleMax);
            
            int randomSpawnNR = Random.Range(0, environmentParts.Length-1);
            
            if (randomRotation)
            {
                rotation = randomRot;
            }

            if (randomScale)
            {
                scale = randomScaleFactor;
            }
            
            var objectMade = Instantiate(environmentParts[randomSpawnNR], new Vector2(randomSpawnPos, spawnAreaY), Quaternion.Euler(new Vector3(0, 0, rotation)));

            objectMade.transform.localScale = new Vector3(scale, scale, scale);
                
            currentSpawnCooldown = spawnCooldown;
        }
    }
}
