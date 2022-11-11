using System.Collections;
using UnityEngine;

public class EnemyShooting : PlayerShooting
{
    private bool canShoot;
    
    private void Update()
    {
        var a = shootCooldown * 3;
        a -= Time.deltaTime;
        if (a > 0) canShoot = true;
        else canShoot = false;
        
        shootCooldown -= Time.deltaTime;
        if(canShoot) Shoot();
    }
}
