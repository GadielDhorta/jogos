using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite imagenAtras;
    CardGameManager MiCardGameManager;

    public Sprite getImagenAtras()
    {
        return imagenAtras;
    }

    private void Start()
    {
        imagenAtras = obtenerImagenAtras();
        MiCardGameManager = GameObject.Find("Cartas").GetComponent<CardGameManager>();

    }
    private Sprite obtenerImagenAtras()
    {
        return gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    private void OnMouseDown()
    {
        rotar();

        MiCardGameManager.CartaClickeada(this);
    }

    public void rotar()
    {
        transform.Rotate(Vector3.up, 180);
    }

    public void destruirse()
    {
        Destroy(gameObject);
    }

}
