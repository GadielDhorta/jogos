using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntajeManager : MonoBehaviour
{
    private GameObject[] estrellas;
    public int puntos = 0;
    // Start is called before the first frame update
    void Start()
    {
        IniciarEstrellas();
        StartCoroutine(MostrarEstrellasDespues(2));

    }

    private IEnumerator MostrarEstrellasDespues(int puntaje)
    {
        yield return  new WaitForSeconds(3);
        MostrarEstrellas(puntaje);
    }

    private void OnEnable()
    {
        EventManager.JuegoGanado += MostrarEstrellas;
    }

    private void OnDisable()
    {
        EventManager.JuegoGanado -= MostrarEstrellas;
    }

    void IniciarEstrellas()
    {
        estrellas = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            estrellas[i] = transform.GetChild(i).gameObject;
            estrellas[i].SetActive(false);
        }
    }

    public void MostrarEstrellas(int puntaje)
    {
        Debug.Log(puntaje);
        for (int i = 0; i < puntaje; i++) 
        {
            estrellas[i].SetActive(true);
            estrellas[i].GetComponent<Animator>();
            Debug.Log(i);
            new WaitForSeconds(1.5f);
        }
            
    }

   }
