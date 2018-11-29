using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {
    // Use this for initialization
    public Controlador player;
    private Rigidbody2D rb2d;
	void Start () {
        player = GetComponentInParent<Controlador>();
        rb2d = GetComponentInParent<Rigidbody2D>();
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);       //¨Pone la velocidad de el personaje en 0 cuando toca una plataforma
            player.transform.parent = col.transform;       //Si esta tocando una plataforma, esta se vuelve su padre
            player.ground = true;
        }
    }
	
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.ground = true;
        }
        if (col.gameObject.tag == "Platform")
        {
            player.transform.parent = col.transform;       //Si esta tocando una plataforma, esta se vuelve su padre
            player.ground = true;
        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
           
            player.ground = false;
        }
        if (col.gameObject.tag == "Platform")
        {
            player.transform.parent = null;             //Si deja de tocar una plataforma, vuelve a no tener padre
            player.ground = false;
        }
    }
  
}
