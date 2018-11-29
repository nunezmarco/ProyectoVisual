using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batController : MonoBehaviour {
    public float visionRadius;
    public float speed;
    public bool following;
    public bool initialpos;
    private Animator anim;
    GameObject player;
    Vector3 initialPosition;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;   
	}
	
	void Update () {
     
        Vector3 target = initialPosition;           
        if (initialPosition.x == transform.position.x && initialPosition.y == transform.position.y) //Verifica si esta en la posicion inicial
        {
            initialpos = true;       
        }
        else
        {
            initialpos = false;
        }
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius)
        {
            following = true;                      //Si el personaje entra a el radio de vision, el enemigo comienza a seguirlo
            target = player.transform.position;
        }
        else
        {
            following = false;
        }
        if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);           //Cambio de direccion
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);            //Cambio de direccion
        }
        float fixedSpeed = speed * Time.deltaTime;
        anim.SetBool("initialpos", initialpos);                 //Setea las variables para la animacion
        anim.SetBool("Following", following);
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        Debug.DrawLine(transform.position, target, Color.green);
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Attack")
        {
            Destroy(gameObject);             //Si es atacado por el collider de la espada, se destruye este objeto
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player" || col.gameObject.tag == "test")
        {
            col.collider.SendMessageUpwards("Burning", null, SendMessageOptions.DontRequireReceiver);  //Si este objeto toca a el personaje, lo daña
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
