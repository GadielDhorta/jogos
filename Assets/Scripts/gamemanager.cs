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
    public static float TiempoDeRotacion = 0.5f;
}

public class gamemanager : MonoBehaviour
{
    public GameObject transition;   //Se indica el prefab "Transicion"
    public AudioSource musicMixer;  //Se indica el mixer "Musica"


    public static string nivelActual = "Geometria";
    // eventos
    void OnEnable()
    {
        EventManager.JuegoGanado += MostrarFinJuego;
    }

    void OnDisable()
    {
        EventManager.JuegoGanado -= MostrarFinJuego;

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

        IniciarJuego(nivelActual);
    }

    private void IniciarJuego(string nivel)
    {
        if (SceneManager.GetActiveScene().name.Contains("Juego"))
        {
            EventManager.OnGameStarted(nivel);
        }
    }

    private void MostrarFinJuego(int Puntaje)
    {
        Debug.Log("Puntaje(en estrellas):");
        Debug.Log(Puntaje);

        IrAEscenaScore();
    }

    public void LoadScene(string scene)     //Resuleve en una corutina a que escena realizar el cambio y su animacion
    {
        StartCoroutine(TransitionOut(scene));
    }
    
    public void IrAEscenaScore()
    {
        LoadScene("Score");

    }
    public void RestartToMenu()                
    {
        LoadScene("Main");
    }
    public void RestartToGameEasy()                 
    {
        EventManager.OnGameStarted(nivelActual);
        LoadScene("JuegoFacil");
    }
        public void RestartToGameMedium()                 
    {
        EventManager.OnGameStarted(nivelActual);
        LoadScene("JuegoMedio");
    }
        public void RestartToGameHard()                 
    {
        EventManager.OnGameStarted(nivelActual);
        LoadScene("JuegoDificil");
    }

    public void CargarEscenaNiveles()                
    {
        LoadScene("Niveles");
    }
    public void CargarEscenaDificultades()                
    {
        LoadScene("Dificultades");
    }

    public void SeleccionarNivel(string nivel){
        nivelActual = nivel;
        CargarEscenaDificultades();
    }
    
    public void RestartScene()                
    {
        LoadScene(SceneManager.GetActiveScene().name);
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

    public void NotifyButtonClick()
    {
        EventManager.OnButtonClickeado();
    }

}
