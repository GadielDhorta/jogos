using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    private CardController[] Cartas = new CardController[2];
    private int numClicks = 0;

    private void Start()
    {

    }
    public void CartaClickeada(CardController Carta)
    {
        Debug.Log("carta clickeada");
        Debug.Log(Cartas[0]);
        Debug.Log(Cartas[1]);


        numClicks += 1;

        Cartas[numClicks - 1] = Carta;

        if (numClicks == 2)
        {
            numClicks = 0;

            if (Cartas[0].getImagenAtras().name == Cartas[1].getImagenAtras().name)
            {
                Cartas[0].destruirse();
                Cartas[1].destruirse();
            }
            else
            {
                Cartas[0].rotar();
                Cartas[1].rotar();
            }
        }
    }
}
