using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject PanelAtras;
    Sprite imagenAtras;
    CardGameManager MiCardGameManager;

    public Sprite getImagenAtras()
    {
        return PanelAtras.GetComponent<SpriteRenderer>().sprite;
    }

    public void SetearImagenAdelante(Sprite sprite)
    {
        PanelAtras.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void Start()
    {
        PanelAtras = gameObject.transform.GetChild(1).gameObject;
        MiCardGameManager = GameObject.Find("Cartas").GetComponent<CardGameManager>();

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

    public void SetearImagen()
    {

    }

}
