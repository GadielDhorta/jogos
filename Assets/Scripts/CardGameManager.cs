using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    private CardController[] ParDeCartas = new CardController[2];
    public Sprite[] Sprites;
    private CardController[] TodasLasCartas;
    private int numClicks = 0;
    private int conteoClicksTotal = 0;


    void OnEnable()
    {
        EventManager.SeDescubreCarta += CartaClickeada;
        EventManager.IniciaJuego += InicializarCartas;
        EventManager.SeDesSeleccionaPar += ComprobarSiGanamos;
    }

    void OnDisable()
    {
        EventManager.SeDescubreCarta -= CartaClickeada;
        EventManager.IniciaJuego -= InicializarCartas;
        EventManager.SeDesSeleccionaPar -= ComprobarSiGanamos;
    }


    void InicializarCartas()
    {
        TodasLasCartas = new CardController[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            TodasLasCartas[i] = transform.GetChild(i).gameObject.GetComponent<CardController>();
        }

        if (Sprites.Length < TodasLasCartas.Length / 2)
        {
            Debug.Log("Error, no nos alcanzan los sprites");
        }


        // randomizando
        System.Random rnd = new System.Random();
        CardController[] TodasLasCartasRandom = TodasLasCartas.OrderBy(x => rnd.Next()).ToArray();

        //asignando imagen por par
        int lastIndex = TodasLasCartas.Length - 1;
        for (int i = 0; i < TodasLasCartas.Length / 2; i++)
        {
            // los pares no se repiten, por lo que la cantidad de pares es cantidad de cartas /2
            int indiceImagen = i;

            TodasLasCartasRandom[i].SetearImagenAdelante(Sprites[indiceImagen]);
            TodasLasCartasRandom[lastIndex - i].SetearImagenAdelante(Sprites[indiceImagen]);
        }

    }


    public void CartaClickeada(CardController Carta)
    {
        numClicks += 1;
        conteoClicksTotal += 1;

        ParDeCartas[numClicks - 1] = Carta;

        if (numClicks == 2)
        {
            numClicks = 0;

            if (ParDeCartas[0].transform.position.Equals(ParDeCartas[1].transform.position))
            {
                ParDeCartas[0] = null;
                ParDeCartas[1] = null;
                return;
            }

            EventManager.OnParSeleccionado();

            if (ParDeCartas[0].getImagenAdelante().name == ParDeCartas[1].getImagenAdelante().name)
            {
                ParDeCartas[0].destruirse();
                ParDeCartas[1].destruirse();

            }
            else
            {
                ParDeCartas[0].Ocultar();
                ParDeCartas[1].Ocultar();
            }
        }
    }

    public void ComprobarSiGanamos()
    {
        StartCoroutine(ComprobarSiGanamosElJuego());
    }

    private IEnumerator ComprobarSiGanamosElJuego()
    {
        // hay que esperar un tiempo porque hacer esto con eventos no sirve, unity tarda en destruir los objetos
        yield return new WaitForSeconds(Globales.TiempoDeMuestraDeCartas);

        EventManager.OnParDesSeleccionado();

        if (transform.childCount == 0)
        {
            EventManager.OnGanamosElJuego(this.Puntaje());
        }

    }

    private int Puntaje()
    {
        int baseMuyBueno = 3;
        int baseBueno = 4;
        int baseMalo = 6;

        int pares = TodasLasCartas.Length / 2;
        int factor = pares - 1;

        int resultado = 0;

        Debug.Log("Clicks");
        Debug.Log(conteoClicksTotal);

        if (conteoClicksTotal == pares)
        {
            // perfecto
            resultado = 4;
        }
        else if (conteoClicksTotal <= baseMuyBueno)
        {
            resultado = 3;
        }
        else if (conteoClicksTotal <= baseBueno)
        {
            resultado = 2;
        }
        else if (conteoClicksTotal <= baseMalo)
        {
            resultado = 1;
        }
        else
        {
            resultado = 0;
        }


        return resultado;
    }
}
