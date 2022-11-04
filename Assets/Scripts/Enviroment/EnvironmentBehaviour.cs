using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBehaviour : MonoBehaviour
{
    public float moveSpeed;
    public float lifeSpan;
    private float age;
    
    // Update is called once per frame
    void Update()
    {
        Move();
        Despawn();
    }

    void Move()
    {
        transform.position += Vector3.down * moveSpeed;
    }
    
    void Despawn()
    {
        age += Time.deltaTime;

        if (age >= lifeSpan)
        {
            Destroy(gameObject);
        }
    }
}
