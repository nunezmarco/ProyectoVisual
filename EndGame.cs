using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Facebook.Unity;
using UnityEngine.UI;
public class EndGame : MonoBehaviour {

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
                SceneManager.LoadScene("Creditos");
                FB.ShareLink(new System.Uri("https://docs.google.com/document/d/1vcVPv7yHUlZcMY5nUmMkAKKp0jk25xHuw7qdTsMv3jA/edit?usp=sharing"), "Acabo de ganar el juego!",
                        "",
                        new System.Uri("https://i.ibb.co/pXNWxzV/Character.png"));

                
                touching = false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player" || col.gameObject.tag == "test")
        {
            touching = true;                 //Si el jugador toca la puerta, habilita terminar el juego
        }
    }
}
