using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float speed = 1f;
    public float maxSpeed = 1f;

    private Rigidbody2D rb2d;
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb2d.AddForce(Vector2.right * speed);
        float limitspeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitspeed, rb2d.velocity.y);
        
        if(rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        if (speed > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);            //Movimiento del enemigo
        }

        if (speed < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Attack")
        {
            Destroy(gameObject); //Si el jugador lo ataca, se destruye
        }
        
        if (col.isTrigger &&col.usedByEffector==true)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);         //Colisiona con los bordes
        }
        if(col.gameObject.tag== "Player")
        {
            if(transform.position.y < col.transform.position.y)
            {
                col.SendMessage("EnemyJump");             //hace brincar al jugador y se destruye el enemigo
                Destroy(gameObject);
            }
            else
            {
                col.SendMessage("EnemyKick",transform.position.x);        //Ataca a el jugador
            }
        }
    }
}
