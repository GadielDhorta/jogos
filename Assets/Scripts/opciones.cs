using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.Audio;
using UnityEngine.UI;

public class opciones : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioSource musicMixer;

    public Slider brillo;

    private void Start()
    {
        musicMixer = GameObject.Find("Musica").GetComponent<AudioSource>();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }

    public void SetVolumemusica(float volume)
    {
        musicMixer.volume = volume;
        Debug.Log("volumen de la musica" + volume);
    }

    void OnGUI()
    {
        new WaitForSeconds(3);
       // Debug.Log(1 / Time.deltaTime);
    }

    void update()
    { 
        Screen.brightness = brillo.value;
        Debug.Log(Screen.brightness);
    }
}


