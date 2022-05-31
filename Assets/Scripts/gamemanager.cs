using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;

public static class Globales
{
    public static float TiempoDeMuestraDeCartas = 1f;

}

public class GameManager : MonoBehaviour
{
    public GameObject transition;   //Se indica el prefab "Transicion"
    public AudioMixer audioMixer;   //Se indica el mixer "Master"
    public AudioSource musicMixer;  //Se indica el mixer "Musica"
    public Slider brillo;           //Se indica el slider "Brillo"


    // eventos
    void OnEnable()
    {
        EventManager.GanamosElJuego += MostrarFinJuego;
    }

    void OnDisable()
    {
        EventManager.GanamosElJuego -= MostrarFinJuego;
    }

    private void Start()
    {
        musicMixer = GameObject.Find("MusicManager").GetComponent<AudioSource>();   //Busca el objeto musica para cambiarle el volumen

        if (transition == null)
        {
            transition = GameObject.Find("Canvas").transform.Find("Transicion").gameObject;
        }
        transition.SetActive(true);                             //Activa capa "Transicion"
        transition.GetComponent<Animator>().Play("entrada");                        //Activa la animacion de entrada a la escena
    }

    private void MostrarFinJuego()
    {
        GameObject.Find("Canvas").transform.Find("Ganaste").gameObject.SetActive(true);
    }

    public void LoadScene(string scene)     //Resuleve en una corutina a que escena realizar el cambio y su animacion
    {
        StartCoroutine(TransitionOut(scene));
    }
    public void RestartToMenu()                 //Cambia a escena Menu
    {
        LoadScene("Main");
    }
    public void RestartToGame()                 //Cambia a escena SampleScene
    {
        EventManager.OnGameStarted();
        LoadScene("Juego");
    }

    IEnumerator TransitionOut(string scene)
    {
        transition.GetComponent<Animator>().Play("salida");     //Ejecuta la animacion "salida" de "Transicion"
        yield return new WaitForSeconds(1);                     //Espera 1 segundo para poder ejecutar la animacion completa
        SceneManager.LoadScene(scene);                         //Carga escena "string"
    }

    public void Exit()                                 //Salir de la aplicacion
    {
        Application.Quit();
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }

    //A partir de aqui esta el codigo para manejar la escena Opciones
    public void SetVolume(float volume)         //Cambia el volumen General
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetVolumemusica(float volume)   //Cambia el volumen de la Musica 
    {
        musicMixer.volume = volume;
    }
    public void Brillo()                               //Cambia el brillo de la pantalla 
    {
        Screen.brightness = brillo.value;
    }

    public void NotifyButtonClick()
    {
        EventManager.OnButtonClickeado();
    }

}
