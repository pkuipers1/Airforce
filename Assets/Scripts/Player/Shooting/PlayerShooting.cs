using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private UnityEvent onShoot = new UnityEvent();

    protected float shootCooldown;
    [SerializeField] private float reloadSpeed;

    [SerializeField] private List<GameObject> bulletSpawnpoints;

    [SerializeField] private GameObject bullet;
    
    [SerializeField] public List<AudioClip> machineGunSounds;
    [SerializeField] public AudioSource spitfireAudio;
        
    [SerializeField] private float soundDelay;

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
                if (machineGunSounds.Count != 0) StartCoroutine(ShootSounds(bulletSpawnpoints.Count));
            }
            shootCooldown = reloadSpeed;
        }

    }
    
    IEnumerator ShootSounds(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var randomSound = Random.Range(0, machineGunSounds.Count);
            spitfireAudio.PlayOneShot(machineGunSounds[randomSound]);
            yield return new WaitForSeconds(soundDelay);
        }
    }

}
