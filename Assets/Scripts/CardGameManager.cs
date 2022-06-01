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
    private int puntajebase = 0;


    void OnEnable()
    {
        EventManager.SeDescubreCarta += CartaClickeada;
        EventManager.IniciaJuego += InicializarCartas;
    }

    void OnDisable()
    {
        EventManager.SeDescubreCarta -= CartaClickeada;
        EventManager.IniciaJuego -= InicializarCartas;
    }


    void InicializarCartas()
    {
        TodasLasCartas = new CardController[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            TodasLasCartas[i] = transform.GetChild(i).gameObject.GetComponent<CardController>();
        }

        // randomizando
        System.Random rnd = new System.Random();
        CardController[] TodasLasCartasRandom = TodasLasCartas.OrderBy(x => rnd.Next()).ToArray();

        //asignando imagen por par
        int lastIndex = TodasLasCartas.Length - 1;
        for (int i = 0; i < TodasLasCartas.Length / 2; i++)
        {
            int indiceImagen = Random.Range(0, Sprites.Length);

            TodasLasCartasRandom[i].SetearImagenAdelante(Sprites[indiceImagen]);
            TodasLasCartasRandom[lastIndex - i].SetearImagenAdelante(Sprites[indiceImagen]);
        }

    }

    public void CartaClickeada(CardController Carta)
    {
        numClicks += 1;
        puntajebase += 1;

        Debug.Log("PuntajeBase");
        Debug.Log(puntajebase);

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

            ComprobarSiGanamos();
        }
    }

    public void ComprobarSiGanamos()
    {
        StartCoroutine(ComprobarSiGanamosElJuego());
    }

    private IEnumerator ComprobarSiGanamosElJuego()
    {
        yield return new WaitForSeconds(Globales.TiempoDeMuestraDeCartas * 2);

        EventManager.OnParDesSeleccionado();

        if (transform.childCount == 0)
        {
            EventManager.OnGanamosElJuego();
        }

    }
}
