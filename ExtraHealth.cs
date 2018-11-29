using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHealth : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player" )
        {
            col.SendMessage("ExtraHP");   //Llama a la funcion de curar de el jugador y se elimia el objeto

            Destroy(gameObject);
        }
    }
}
