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
        numClicks += 1;


        Debug.Log(Carta.name);

        if (Cartas[numClicks - 1] == null)
        {
            Cartas[numClicks - 1] = Carta;
        }

        if (numClicks == 2)
        {
            numClicks = 0;

            if (Cartas[0].getImagenAtras().name == Cartas[1].getImagenAtras().name)
            {
                Debug.Log("Eureka");

                Cartas[0].destruirse();
                Cartas[1].destruirse();
            }
        }
    }
}
