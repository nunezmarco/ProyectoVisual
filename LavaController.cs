using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
            
        if ( col.gameObject.tag == "Player"|| col.gameObject.tag == "test")
        {
            
                col.collider.SendMessageUpwards("Burning", null, SendMessageOptions.DontRequireReceiver);   //Envia el mensaje al jugador para recibir daño
           
            
        }
    }
    
}
