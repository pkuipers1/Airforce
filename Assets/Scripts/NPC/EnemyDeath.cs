using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private List<TagManager> currentEnemies;
    [SerializeField] private List<TagManager> currentDeadEnemies;

    private float destroyDelayTimer = 1f;
    private float timePassed;
    private bool startDestroyTimer;

    private void Update()
    {
        currentEnemies = TagManagerExtentions.FindAllWithTag("Enemy");
        currentDeadEnemies = TagManagerExtentions.FindAllWithTag("Dead");

        if (currentDeadEnemies.Count >= currentEnemies.Count)
        {
            DestroyAllEnemies();
            startDestroyTimer = true;
        }

        if (startDestroyTimer)
        {
            timePassed += Time.deltaTime;
        }
    }

    public void Destroy()
    {
        gameObject.AddTag("Dead");
        transform.Translate(15, 0, 0);
    }

    public void DestroyAllEnemies()
    {
        if (timePassed >= destroyDelayTimer)
        {
            foreach (var enemy in currentDeadEnemies)
            {
                Destroy(enemy.gameObject);
            }
        }
    }
}
