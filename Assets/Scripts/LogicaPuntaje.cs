using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//control del componente puntaje del jugador que acumula las banderas que va teniendo el jugador
public class LogicaPuntaje : MonoBehaviour
{
    public int puntajeJugador; //crea variable de puntaje del jugador

  // Start is called before the first frame update
    void Start()
    {
        puntajeJugador = 0; //inicializa la variable en cero cuando comienza el juego
    }

    public void incremento(int valor)
    {
        puntajeJugador += valor; //suma el puntaje que va obteniendo a la variable que acumula el mismo
    }

}
