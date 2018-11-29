using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLvl2 : MonoBehaviour {
    private bool touching = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (touching == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Nivel3");         //Carga el nivel 3 
                touching = false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player" || col.gameObject.tag == "test")
        {
            touching = true;       //Habilita el paso al siguiente nivel
        }
    }
}
