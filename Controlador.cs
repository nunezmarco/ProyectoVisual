using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour {
    public float speed = 75;
    private Rigidbody2D rb2d;
    public float maxSpeed = 3;
    public bool ground;
    public float jumpPower = 9.25f;
    private Animator anim;
    private bool jump;
    private bool doublejump;
    private bool movement = true;
    private SpriteRenderer spr;
    private GameObject healthbar;
    CircleCollider2D attackCollider;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        healthbar = GameObject.Find("HP");
        attackCollider = transform.GetChild(1).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Ground", ground);
        if (ground == true)
        {
            doublejump = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (ground == true)
            {
                jump = true;
                doublejump = true;
            }
            else if (doublejump == true)
            {
                jump = true;        //Activa un doble salto y deshabilita la opcion de dar un 3er salto
                doublejump = false;
            }
        }
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);   //Obtiene la animacion que esta haciendo el personaje
        bool attacking = stateInfo.IsName("Player_Atack");                 //Verifica si esta atacando
        if (Input.GetKeyDown("space")&& !attacking)
        {
            anim.SetTrigger("Attacking");
        }
        if (attacking)
        {
            float playbackTime = stateInfo.normalizedTime;      //Tiempo en el que el collider existira
            if (playbackTime > 0.44 && playbackTime < 1.55)
            {
                attackCollider.enabled = true;                  //habilita el collider de el ataque
            }
            else
            {
                attackCollider.enabled = false;
            }
        }
    }

    void FixedUpdate()
    {
       
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.7f;
        if (ground)
        {
            rb2d.velocity = fixedVelocity;
        }
        float h = Input.GetAxis("Horizontal");
        if (!movement)
        {
            h = 0;
        }
        rb2d.AddForce(Vector2.right*speed*h);

        float limitspeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitspeed, rb2d.velocity.y);

        if(h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);    //Cambio de direccion en las imagenes (flip)
        }

        if (h < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);     //Cambio de direccion en las imagenes (flip)
        }
        if (jump == true)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower,   ForceMode2D.Impulse);
            jump = false;
        } 

    }

 
    public void ExtraHP()
    {
        healthbar.SendMessage("Healing", 20);           //Reestablece 20 de hp
    }
    public void EnemyJump()
    {
        jump = true;        //Al pisar un enemigo, salta automaticamente
    }
    public void EnemyKick(float enemyposx)
    {
        healthbar.SendMessage("damage", 20);             //Recibe 20 de daño
        jump = true;
        float side = Mathf.Sign(enemyposx-transform.position.x);   //Direccion del salto
        rb2d.AddForce(Vector2.left * side*jumpPower, ForceMode2D.Impulse);
        movement = false;
        Invoke("enablemovement", 0.7f);         //Bloquea el movimiento por .7 segs
        spr.color = Color.red;                    //Cambia el color del personaje a rojo
    }
    
    public void Burning()
    {
        healthbar.SendMessage("damage", 20);           //Resta 20 de daño a la HP
        jump = true;
        Invoke("enablemovement", 0.3f);
        spr.color = Color.red;
    }
    void enablemovement()
    {
        movement = true;                       //Reestablece el movimiento del personaje
        spr.color = Color.white;            //Reestablece el color original
    }

    
}
