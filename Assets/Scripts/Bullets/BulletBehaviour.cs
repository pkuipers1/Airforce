using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletBehaviour : MonoBehaviour
{
    [Header("Bullet Stats")]
    [SerializeField] private float bulletLifespan;
    [SerializeField] private float bulletSpeed;
    private float bulletAge;

    [Header("Unity Events")] 
    [SerializeField] private UnityEvent onShoot = new UnityEvent();
    [SerializeField] public UnityEvent onHitTarget = new UnityEvent();
    [SerializeField] private UnityEvent onDeath = new UnityEvent();
    
    void Start()
    {
        bulletAge = 0;
    }
    
    void Update()
    {
        BulletDeathOverTime();
        Move();
    }

    private void BulletDeathOverTime()
    {
        bulletAge += Time.deltaTime;
        
        if (bulletAge > bulletLifespan)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position += Vector3.up * bulletSpeed;
    }
}
