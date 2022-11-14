using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class HealthData : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    private float _maxHealth;
    private PlayEffects playEffects;

    [SerializeField] private List<ParticleSystem> damageEffects;
    [SerializeField] private ParticleSystem deathEffect;

    public UnityEvent<HealthEvent> onHealthChanged = new UnityEvent<HealthEvent>();
    [SerializeField] private UnityEvent onHealthAdded = new UnityEvent();
    [SerializeField] private UnityEvent onDamageTaken = new UnityEvent();
    [SerializeField] private UnityEvent onDie = new UnityEvent();
    [SerializeField] private UnityEvent onResurrected = new UnityEvent();

    public float Health => health;
    public float MaxHealth => _maxHealth;
    public bool HasMaxHealth => health >= _maxHealth;
    
    private bool _isHit;
    [HideInInspector] public bool isDead;

    private void Awake()
    {
        playEffects = gameObject.GetComponent<PlayEffects>();
    }

    private void Start()
    {
        InitHealth();
    }
    
    private void InitHealth()
    {
        _maxHealth = health;
    }

    public void AddHealth(float healthAmount)
    {
        if (isDead || HasMaxHealth) return;

        health += healthAmount;

        onHealthAdded?.Invoke();
        TriggerChangedEvent(HealthEventTypes.AddHealth, healthAmount);
    }

    private void TriggerChangedEvent(HealthEventTypes type, float healthDelta = 0)
    {
        var healthEvent = new HealthEvent()
        {
            type = type,
            target = gameObject,
            currenthealth = Health,
            healthDelta = healthDelta,
            maxHealth = MaxHealth
        };
        onHealthChanged?.Invoke(healthEvent);
    }

    public void Resurrect(float newHealth)
    {
        isDead = false;
        AddHealth(newHealth);
        onResurrected?.Invoke();
        
        TriggerChangedEvent(HealthEventTypes.Resurrect, newHealth);
    }

    public void TakeDamage(float damage)
    {
        if (isDead || _isHit) return;

        _isHit = true;
        health -= damage;
        onDamageTaken?.Invoke();
        CheckHealthPercentage();
        TriggerChangedEvent(HealthEventTypes.TakeDamage, damage);
        _isHit = false;
        
        if (health <= 0) Die();
    }

    private void Die()
    {
        var deathLocation = gameObject.transform.position;
        health = 0;
        isDead = true;
        gameObject.AddTag("Dead");
        onDie?.Invoke();
        playEffects.PlayDeathEffect(deathLocation);
        TriggerChangedEvent(HealthEventTypes.Die);
    }

    public void Kill()
    {
        Die();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    
    private void CheckHealthPercentage()
    {
        if (damageEffects.Count == 0) return;
        
        var healthPercentage = MaxHealth / 100 * health;
        
        switch (healthPercentage)
        {
            case 50:
            {
                AssignDamageEffect();
                break;
            }
            case 40:
            {
                AssignDamageEffect();
                break;
            }
            case 30:
            {
                AssignDamageEffect();
                break;
            }
            case 20:
            {
                AssignDamageEffect();
                break;
            }
            case 10:
            {
                AssignDamageEffect();
                break;
            }
            case 0:
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                break;
            }
        }
    }

    private void AssignDamageEffect()
    {
        int randomEffect = Random.Range(0, damageEffects.Count);

        if (damageEffects[randomEffect].isPlaying)
        {
            AssignDamageEffect();
        }
        else
        {
            damageEffects[randomEffect].Play();
        }
    }
}