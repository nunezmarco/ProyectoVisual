using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Facebook.Unity;
using UnityEngine.UI;
public class Menu : MonoBehaviour {
    public GameObject flecha, lista;
    
    int indice = 0;
	void Start () {
        Dibujar();
	}

    void Dibujar()
    {
        Transform opcion = lista.transform.GetChild(indice);
        flecha.transform.position = opcion.position;
    }

   

 

    // Update is called once per frame
    void Update () {
        bool up = Input.GetKeyDown("up");                 //Se controla el movimiento con las flechas arriba y abajo del teclado
        bool down = Input.GetKeyDown("down");
        if (up)
        {
            indice--;
        }
        if (down)
        {
            indice++;
        }
        if(indice> lista.transform.childCount - 1)
        {
            indice = 0;

        }
        else if (indice < 0)
        {
            indice = lista.transform.childCount - 1;             //Obtiene los hijos de la lista para verificar el indice
        }
        if (up || down)
        {
            Dibujar();
        }
        if (Input.GetKeyDown("return"))                   //si aprietas Enter, llama la funcion click que carga las escenas
        {
            Click();
        }
    }
    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                    Debug.LogError("Couldn't initialize");          //Inicializa los servicios de Facebook
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        }
        else
            FB.ActivateApp();
    }
    void Click()
    {
        Transform opcion = lista.transform.GetChild(indice);

        if (opcion.gameObject.gameObject.name == "Salir")
        {
            Application.Quit();
        }
        else
        {
            if (opcion.gameObject.gameObject.name == "Nuevo")
            {
                
                SceneManager.LoadScene("Nivel1");                                  //Verifica todas las opciones del menu y envia a diferentes escenas
                                                                                   //De a cuerdo a lo elejido
            }
            else 
            if(opcion.gameObject.gameObject.name== "Invitar"){

                    FB.AppRequest("Ven a pribar este juego super genial!", title: "Project"); 
            }
            else
                SceneManager.LoadScene(opcion.gameObject.name);
            
        }

    }

}
