using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private float shootCooldown;
    [SerializeField] private float reloadSpeed;

    [SerializeField] private List<GameObject> bulletSpawnpoints;

    [SerializeField] private GameObject bullet;

    private void Update()
    {
        shootCooldown -= Time.deltaTime; }

    public void Shoot(float shootInput)
    {
        if (shootInput == 0) return;

        if (shootCooldown <= 0)
        {
            foreach (var spawnpoint in bulletSpawnpoints)
            {
                Instantiate(bullet, spawnpoint.transform.position, quaternion.identity);
            }
            shootCooldown = reloadSpeed;
        }

    }
}
