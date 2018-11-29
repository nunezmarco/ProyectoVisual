using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followlvl3 : MonoBehaviour {

    public GameObject followw;          //Obtiene el objeto que va a seguir, en este caso al Player
    public Vector2 mincampos, maxcampos;   //Declara la posixion minima y maxima de la camara
    public float smoothtime;               //Suavizado para el mov de la camara
    private Vector2 vel;
    // Use this for initialization
    void Start()
    {

    }
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, followw.transform.position.x, ref vel.x, smoothtime);
        double posYd = Mathf.SmoothDamp(transform.position.y, followw.transform.position.y, ref vel.y, smoothtime) ;   //Sigue a el jugador 
        float posY = (float)posYd;
        transform.position = new Vector3(posX, posY, transform.position.z);

    }
}
