using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private UnityEvent onShoot = new UnityEvent();

    protected float shootCooldown;
    [SerializeField] private float reloadSpeed;

    [SerializeField] private List<GameObject> bulletSpawnpoints;

    [SerializeField] private GameObject bullet;

    private void Update()
    {
        shootCooldown -= Time.deltaTime; 
    }

    public void Shoot(float shootInput = 1)
    {
        if (shootInput == 0) return;

        if (shootCooldown <= 0)
        {
            foreach (var spawnpoint in bulletSpawnpoints)
            {
                onShoot?.Invoke();
                Instantiate(bullet, spawnpoint.transform.position, quaternion.identity);
            }
            shootCooldown = reloadSpeed;
        }

    }
}
