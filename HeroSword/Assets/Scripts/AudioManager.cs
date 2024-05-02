using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider controlVolumen;
    public GameObject[] audios;

    private void Start()
    {
        audios = GameObject.FindGameObjectsWithTag("audio");
        float volumenGuardado = PlayerPrefs.GetFloat("volumenSave", 0.5f);

        controlVolumen.value = volumenGuardado;

        AplicarVolumenGuardado(volumenGuardado);
    }

    private void Update()
    {
        foreach (GameObject au in audios)
            au.GetComponent<AudioSource>().volume = controlVolumen.value;
    }

    public void guardarVolumen()
    {
        PlayerPrefs.SetFloat("volumenSave", controlVolumen.value);
    }
    private void AplicarVolumenGuardado(float volumen)
    {
        foreach (GameObject au in audios)
        {
            AudioSource audioSource = au.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = volumen;
            }
        }
    }
}
