using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reinicarjuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void recargarjuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void irmenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

