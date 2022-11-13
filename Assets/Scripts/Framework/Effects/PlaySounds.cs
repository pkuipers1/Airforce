using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    [SerializeField] private AudioClip hitSound;
    
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }
}
