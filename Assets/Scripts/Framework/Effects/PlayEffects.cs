using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffects : MonoBehaviour
{
    public List<ParticleSystem> effects;

    public void PlayAll()
    {
        foreach (var effect in effects)
        {
            effect.Play();
        }
    }
}
