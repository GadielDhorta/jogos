using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject transicion;
    public AudioSource kick;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        transicion.SetActive(true);

    }

    public void OnMouseDown()
    {
       kick.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
