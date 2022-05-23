using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awaketransicion : MonoBehaviour
{
    public GameObject transicion;
    // Start is called before the first frame update
    private void Awake()
    {
        transicion.SetActive(true);
    }
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
