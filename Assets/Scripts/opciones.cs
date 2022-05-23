using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.Audio;
using UnityEngine.UI;

public class opciones : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider brillo;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }

    public void SetVolumemusica(float musica)
    {
        audioMixer.SetFloat("volumemusica", musica);
        Debug.Log(musica);
    }

    void OnGUI()
    {
        new WaitForSeconds(3);
        Debug.Log(1 / Time.deltaTime);
    }

    void update()
    { 
        Screen.brightness = brillo.value;
        Debug.Log(Screen.brightness);
    }
}


