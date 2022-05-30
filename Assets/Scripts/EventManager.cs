using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public static event Action<CardController> CartaRotada = delegate { };

    public static event Action CartaDestruida = delegate { };

    public static event Action GameStarted = delegate { };

    public static event Action ParSeleccionado = delegate { };
    public static event Action ParDesSeleccionado = delegate { };
    public static event Action GanamosElJuego = delegate { };


    public static void OnCartaDestruida()
    {
        Debug.Log("CartaDestruida");
        CartaDestruida();
    }
    public static void OnCartaRotada(CardController carta)
    {
        Debug.Log("CartaRotada");
        CartaRotada(carta);
    }
    public static void OnGameStarted()
    {
        Debug.Log("GameStarted");
        GameStarted();
    }
    public static void OnParSeleccionado()
    {
        Debug.Log("ParSeleccionado");
        ParSeleccionado();
    }

    public static void OnParDesSeleccionado()
    {
        Debug.Log("ParDesSeleccionado");
        ParDesSeleccionado();
    }

    public static void OnGanamosElJuego()
    {
        Debug.Log("Ganamos el juego!");
        GanamosElJuego();
    }

}
