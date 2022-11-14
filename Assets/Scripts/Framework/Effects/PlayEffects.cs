using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffects : MonoBehaviour
{
    public List<ParticleSystem> effects;
    public ParticleSystem deathEffect;

    public void PlayAll()
    {
        foreach (var effect in effects)
        {
            effect.Play();
        }
    }

    public void PlayDeathEffect(Vector3 deathLocation)
    {
        Instantiate(deathEffect, deathLocation, Quaternion.identity);
    }
}
