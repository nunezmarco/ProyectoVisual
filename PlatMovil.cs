using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMovil : MonoBehaviour {

    public Transform target;
    public float speed;

    private Vector3 start, end;             //Posicion final e inicial de el movimiento
    // Use this for initialization
    void Start()
    {
        if (target != null)
        {
            target.parent = null;          //Le pone a el padre de el target como NULL asi se queda quieto
            start = transform.position;
            end = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (target != null)
        {
            float fixedspeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedspeed);
        }
        if(transform.position== target.position)
        {
            if (target.position == start)
            {
                target.position = end;                     //si estamos al final, el target cambia a el inicio,
                                                           //si estamos al inicio, el target cambia a el final
            }
            else
                target.position = start;
                
        }
    }
}
