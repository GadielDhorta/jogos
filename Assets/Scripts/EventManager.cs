using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public static event Action<CardController> SeDescubreCarta = delegate { };
    public static event Action<CardController> SeOcultaCarta = delegate { };

    public static event Action SeDestruyeCarta = delegate { };

    public static event Action IniciaJuego = delegate { };

    public static event Action SeSeleccionaPar = delegate { };
    public static event Action SeDesSeleccionaPar = delegate { };
    public static event Action JuegoGanado = delegate { };

    // eventos de interfaz
    public static event Action SeClickeaBoton = delegate { };


    public static void OnCartaDestruida()
    {
        Debug.Log("CartaDestruida");
        SeDestruyeCarta();
    }
    public static void OnCartaDescubierta(CardController carta)
    {
        Debug.Log("CartaDescubierta");
        SeDescubreCarta(carta);
    }

    public static void OnCartaOcultada(CardController carta)
    {
        Debug.Log("CartaOcultada");
        SeOcultaCarta(carta);
    }

    public static void OnGameStarted()
    {
        Debug.Log("GameStarted");
        IniciaJuego();
    }
    public static void OnParSeleccionado()
    {
        Debug.Log("ParSeleccionado");
        SeSeleccionaPar();
    }

    public static void OnParDesSeleccionado()
    {
        Debug.Log("ParDesSeleccionado");
        SeDesSeleccionaPar();
    }

    public static void OnGanamosElJuego()
    {
        Debug.Log("Ganamos el juego!");
        JuegoGanado();
    }

    public static void OnButtonClickeado()
    {
        Debug.Log("ButtonClickeado");
        SeClickeaBoton();
    }

}
