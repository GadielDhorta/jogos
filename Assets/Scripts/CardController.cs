using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject PanelAdelante;

    private float TiempoDeRotacion = 0.5f;
    Sprite imagenAdelante;


    void OnEnable()
    {
        EventManager.ParSeleccionado += ConGelarClickTemporalmente;
        EventManager.ParDesSeleccionado += HabilitarClick;
    }

    void OnDisable()
    {
        EventManager.ParSeleccionado -= ConGelarClickTemporalmente;
        EventManager.ParDesSeleccionado -= HabilitarClick;
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
        Invoke("HabilitarClick", Globales.TiempoDeMuestraDeCartas);
    }

    void CongelarClickIndefinidamente()
    {
        // congelamos click
        this.tag = "Deshabilitado";
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

    private Rotate ScriptDeRotacion()
    {
        return gameObject.GetComponent<Rotate>();
    }

    public void rotar()
    {
        CongelarClickIndefinidamente();
        EventManager.OnCartaRotada(this);
        StartCoroutine(RotarAntesDeTiempo());
    }

    public void RotarSinNotificar()
    {
        StartCoroutine(RotarDespuesDeTiempo());
    }

    private IEnumerator RotarAntesDeTiempo()
    {
        ScriptDeRotacion().StartRotating(TiempoDeRotacion);
        yield return new WaitForSeconds(Globales.TiempoDeMuestraDeCartas);

    }

    private IEnumerator RotarDespuesDeTiempo()
    {
        yield return new WaitForSeconds(Globales.TiempoDeMuestraDeCartas);
        ScriptDeRotacion().StartRotatingBackwards(TiempoDeRotacion);
    }

    public void destruirse()
    {
        StartCoroutine(DestruirDespuesDeTiempo());
    }

    private IEnumerator DestruirDespuesDeTiempo()
    {
        yield return new WaitForSeconds(Globales.TiempoDeMuestraDeCartas);
        Destroy(gameObject);
        EventManager.OnCartaDestruida();
    }


}
