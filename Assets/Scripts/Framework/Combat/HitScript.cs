using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    private HealthData healthData;

    private void Start()
    {
        healthData = gameObject.GetComponent<HealthData>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    { 
        if (col.gameObject.HasTag("PlayerBullet") && gameObject.HasTag("Enemy")) EnemyIsHit(col);
        
        if (col.gameObject.HasTag("EnemyBullet") && gameObject.HasTag("Player")) PlayerIsHit(col);
    }

    private void EnemyIsHit(Collider2D col)
    {
        var bulletBehaviour = col.GetComponent<BulletBehaviour>();
        healthData.TakeDamage(bulletBehaviour.bulletDamage);       
        Debug.Log("Enemy hit functie");
        Destroy(col.gameObject);
    }
    private void PlayerIsHit(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}
