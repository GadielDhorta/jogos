using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    
     private void Start() 
    {
        cam=Camera.main;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch mtouch=Input.GetTouch(0);//obtengo los toques y los amaceno en una var
            Ray ray = Camera.main.ScreenPointToRay(mtouch.position);//proyecto un rayo desde la camara hasta el bojeto con collider
            RaycastHit hit; //extraigo el hit 
            if(Physics.Raycast(ray,out hit))//en caso de que alla colisionado con algo extraigo la su cordenada 
            {
                transform.position=hit.point;   // me muevo en la dir donde me indique la cordenada extraida desde el punto 
            }
            
            

        }



















        
        
    }
//Touch touch= Input.GetTouch(0);//registra el primer toque en  pantalla y lo manda en una variable
           // Vector3 touchPosition=Camera.main.ScreenToWorldPoint(touch.position);//obtengo la infromacion de mi posicion atravez de la cam
            
            //transform.position=touchPosition;//mi pos va a ser dada por el vector del touchPos

}
