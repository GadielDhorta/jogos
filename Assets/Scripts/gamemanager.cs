using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject transition;

    private void Start()
    {
        transition.SetActive(true);
        transition.GetComponent<Animator>().Play("entrada");
    }
    public void LoadScene(string scene)
    {   //hacer transicion de salida
       
        StartCoroutine(TransitionOut(scene));
        
    }

    IEnumerator TransitionOut(string scene)
    {
       // GameObject transicion = GameObject.Find("Transicion");
        transition.SetActive(true);
        transition.GetComponent<Animator>().Play("salida");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);


    }
}
