using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicMixer;
    private static MusicManager instance;
    public AudioClip click;
    private AudioSource mouse;
    public AudioClip flip;
    private AudioSource flipado;


    public static MusicManager GetInstance()
    {
        return instance;
    }

    void OnEnable()
    {
        EventManager.SeClickeaBoton += Reproducirclick;
        EventManager.CartaComienzaADescubrirse += sonidocarta;
        EventManager.SeOcultaCarta += sonidocarta;
    }

    void OnDisable()
    {
        EventManager.SeClickeaBoton -= Reproducirclick;
        EventManager.CartaComienzaADescubrirse -= sonidocarta;
        EventManager.SeOcultaCarta -= sonidocarta;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void SetVolumemusica(float volume)   //Cambia el volumen de la Musica 
    {

        musicMixer = gameObject.GetComponent<AudioSource>();
        Debug.Log("volumen de la musica" + volume);
    }

    private void Start()
    {
        mouse = GetComponent<AudioSource>();
        flipado = GetComponent<AudioSource>();
    }

    public void Reproducirclick()
    {
        mouse.PlayOneShot(click, 1.0f);
    }
    public void sonidocarta(CardController carta)
    {
        flipado.PlayOneShot(flip, 1.0f);
    }
}
