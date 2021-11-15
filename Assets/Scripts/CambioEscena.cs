using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//elemento que hace el cambio de scene al cumplirse el tiempo de la partida. Está en main cámara de la scene del juego
//Tambien hace que aparezca el cursor para poder seleccionar si se desea comenzar una nueva partida o salir del juego
public class CambioEscena : MonoBehaviour
{
    public float tiempoInicio; 
    public float tiempoFin;

    void Start()
    {
    }
    void Update()
    { //En base a las dos variables de tiempo estipuladas, descontará de tiempo fin el tiempo que vaya transcurriendo, cuando iguala a tiempoinicio termina la partida
        tiempoFin -= Time.deltaTime;
        if (tiempoInicio >= tiempoFin)
        {
            SceneManager.LoadScene("FinPartida");         //carga la escena fin de la partida
                Cursor.lockState = CursorLockMode.None; //desbloquea el cursor para seleccionar con el mouse uno de los botones
                Cursor.visible = true;                  //visibiliza el cursor
        }
    }
}
