using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    private CardController[] ParDeCartas = new CardController[2];
    public Sprite[] Sprites;
    private CardController[] TodasLasCartas;
    private int numClicks = 0;

    void Start()
    {
        InicializarCartas();
    }

    void InicializarCartas()
    {
        TodasLasCartas = new CardController[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            TodasLasCartas[i] = transform.GetChild(i).gameObject.GetComponent<CardController>();
        }

        //asignando imagen por par random
        for (int i = 0; i < TodasLasCartas.Length / 2; i++)
        {
            int indiceImagen = Random.Range(0, Sprites.Length);
            int indiceCarta1 = i;
            int indiceCarta2 = Random.Range(TodasLasCartas.Length / 2, TodasLasCartas.Length);
            while (TodasLasCartas[indiceCarta2] == null)
            {
                indiceCarta2 = Random.Range(TodasLasCartas.Length / 2, TodasLasCartas.Length);
            }

            TodasLasCartas[indiceCarta1].SetearImagenAdelante(Sprites[indiceImagen]);
            TodasLasCartas[indiceCarta2].SetearImagenAdelante(Sprites[indiceImagen]);
            TodasLasCartas[indiceCarta1] = null;
            TodasLasCartas[indiceCarta2] = null;

        }

    }

    public void CartaClickeada(CardController Carta)
    {
        numClicks += 1;

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

            if (ParDeCartas[0].getImagenAtras().name == ParDeCartas[1].getImagenAtras().name)
            {
                ParDeCartas[0].destruirse();
                ParDeCartas[1].destruirse();
            }
            else
            {
                ParDeCartas[0].rotar();
                ParDeCartas[1].rotar();
            }
        }
    }
}
