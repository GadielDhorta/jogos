using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntajeManager : MonoBehaviour
{
    private GameObject[] estrellas;
    // Start is called before the first frame update
    void Start()
    {
        IniciarEstrellas();
    }

    void IniciarEstrellas()
    {
        estrellas = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            estrellas[i]=transform.GetChild(i).gameObject;
    }

    public void MostrarEstrellas(int puntaje)
    {
        for (int i = 0; i < puntaje; i++) 
        {
            estrellas[i].GetComponent<Animator>();
        }
            
    }

   }
