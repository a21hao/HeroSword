using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;



    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        audioSource.Play();
    //    }
    //}
    public void PlaySound(AudioClip sound)
    {
        if (sound != null)
            audioSource.PlayOneShot(sound);
    }
}
