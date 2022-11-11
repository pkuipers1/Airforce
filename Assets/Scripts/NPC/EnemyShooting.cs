using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyShooting : PlayerShooting
{
    private void Update()
    {
        shootCooldown -= Time.deltaTime;

        //var shootingInterval = Random.Range(0, 1);
        
        Shoot();
    }
}
