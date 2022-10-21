using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D col)
    { 
        if (col.gameObject.HasTag("PlayerBullet") && gameObject.HasTag("Enemy"))
        {
            Debug.Log("Enemy hit!");
        }
        if (col.gameObject.HasTag("EnemyBullet") && gameObject.HasTag("Player"))
        {
            Debug.Log("Player hit!");
        }
    }
}
