using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platafall : MonoBehaviour {

    private Rigidbody2D rb2d;
    private PolygonCollider2D pc2d;
    private Vector3 start;

    public float delay = 1f;    
    public float respawndelay = 5f;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        pc2d = GetComponent<PolygonCollider2D>();
        start = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))   //Verifica si la plataforma está tocando al jugador
        {
            Invoke("fall", delay);                 //Llama a la funcion de caer despues de 1 segundo
            Invoke("respawn", delay + respawndelay); //Reaparece la plataforma despues de 5 segundos desde que cae 
        }
    }

    void fall()
    {
        rb2d.isKinematic = false;              //Lo devuelve a dinamico para que caiga la plataforma
        pc2d.isTrigger = true;                 //Desactiva las colisiones   
    }

    void respawn()
    {
        transform.position = start; 
        rb2d.isKinematic = true;
        rb2d.velocity = Vector3.zero;
        pc2d.isTrigger = false;
    }
}
