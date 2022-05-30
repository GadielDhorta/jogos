using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject PanelAdelante;
    private float TiempoDeMuestraDeCartas = 1f;
    Sprite imagenAdelante;


    void OnEnable()
    {
        EventManager.ParSeleccionado += ConGelarClickTemporalmente;
    }

    void OnDisable()
    {
        EventManager.ParSeleccionado -= ConGelarClickTemporalmente;
    }
    private void Start()
    {
        PanelAdelante = gameObject.transform.GetChild(1).gameObject;

    }

    private void OnMouseDown()
    {

        if (this.tag != "Deshabilitado")
        {
            rotar();
        }
    }

    void ConGelarClickTemporalmente()
    {
        // congelamos click
        this.tag = "Deshabilitado";
        // habilitamosClick
        Invoke("HabilitarClick", TiempoDeMuestraDeCartas);
    }

    void HabilitarClick()
    {
        this.tag = "Habilitado";
    }


    public Sprite getImagenAdelante()
    {
        return PanelAdelante.GetComponent<SpriteRenderer>().sprite;
    }

    public void SetearImagenAdelante(Sprite sprite)
    {
        PanelAdelante.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private GameObject getCarta()
    {
        return gameObject.transform.parent.gameObject;
    }

    public void rotar()
    {
        EventManager.OnCartaRotada(this);
        StartCoroutine(RotarAntesDeTiempo());
    }

    public void RotarSinNotificar()
    {
        StartCoroutine(RotarDespuesDeTiempo());
    }

    private IEnumerator RotarAntesDeTiempo()
    {
        transform.Rotate(Vector3.up, 180);

        yield return new WaitForSeconds(TiempoDeMuestraDeCartas);

    }

    private IEnumerator RotarDespuesDeTiempo()
    {
        yield return new WaitForSeconds(TiempoDeMuestraDeCartas);
        transform.Rotate(Vector3.up, 180);


    }

    public void destruirse()
    {
        StartCoroutine(DestruirDespuesDeTiempo());
    }

    private IEnumerator DestruirDespuesDeTiempo()
    {
        yield return new WaitForSeconds(TiempoDeMuestraDeCartas);
        Destroy(gameObject);
        EventManager.OnCartaDestruida();
    }


}
