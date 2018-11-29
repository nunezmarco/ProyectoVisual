using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{

    float Health;
    float maxHP = 100;

    public Image hpimage;
    // Use this for initialization
    void Start()
    {
        Health = maxHP;
    }


    void FixedUpdate()
    {
        if (Health <= 0)
        {                             //Si no queda hp, pierde y se va a el menu de inicio
            SceneManager.LoadScene("Menu");
        }
    }

    public void damage(float amount)
    {
        Health = Mathf.Clamp(Health - amount, 0, maxHP);             //Resta hp
        hpimage.transform.localScale = new Vector2(Health / maxHP, 1);
    }

    public void Healing(float amount)
    {

        Health = Mathf.Clamp(Health + amount, 0, maxHP);            //Suma hp
        hpimage.transform.localScale = new Vector2(Health / maxHP, 1);
    }
}
