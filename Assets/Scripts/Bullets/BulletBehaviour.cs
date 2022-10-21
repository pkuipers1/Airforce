using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float bulletLifespan;
    [SerializeField] private float bulletSpeed;
    private float bulletAge;
        
    // Start is called before the first frame update
    void Start()
    {
        bulletAge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bulletAge += Time.deltaTime;
        if (bulletAge > bulletLifespan)
        {
            Destroy(gameObject);
        }
        
        transform.position += Vector3.up * bulletSpeed;
    }
}
