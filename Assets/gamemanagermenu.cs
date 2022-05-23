using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanagermenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void escenajuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void escenaopciones()
    {
        SceneManager.LoadScene("Opciones");
    }

    public void escenasalir()
    {
        SceneManager.LoadScene("Salir");
    }

    public void Acerca()
    {
        SceneManager.LoadScene("Acerca");
    }
}

