using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pelota;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("aparecer",2, 0.03f);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void aparecer()
    { Instantiate(pelota, pelota.transform.position, pelota.transform.rotation); }
}
