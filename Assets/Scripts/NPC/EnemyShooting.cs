using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyShooting : PlayerShooting
{
    private void Update()
    {
        Shoot(1);
    }
}
