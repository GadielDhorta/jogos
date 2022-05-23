using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioentreescenas : MonoBehaviour
{
    private audioentreescenas instance;
    public audioentreescenas Instance
    {
        get 
        {
            return instance;
        }
    }

    public void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else 
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
