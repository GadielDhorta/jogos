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
        if (Cartas[0] != null && Cartas[1] != null)
        {

            if (Cartas[0].gameObject.transform.position == Cartas[1].gameObject.transform.position)
            {
                return;
            }
        }

        numClicks += 1;


        if (Cartas[numClicks - 1] == null)
        {
            Cartas[numClicks - 1] = Carta;
        }

        if (numClicks == 2)
        {
            numClicks = 0;

            if (Cartas[0].getImagenAtras().name == Cartas[1].getImagenAtras().name)
            {

                Cartas[0].destruirse();
                Cartas[1].destruirse();
            }
        }
    }
}
