using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//componente del elemento canva que muestra en la pantalla al ganador de la partida y las banderas del mismo

public class Ganador : MonoBehaviour
{
    public Text texto;
    public int puntaje;
    public int puntaje1;
    // Start is called before the first frame update
    void Awake()
    {                                 //cargará en las variables los puntajes capturados en el objeto que no se destruyó de la escena principal
        puntaje = PlayerPrefs.GetInt("puntaje"); 
        puntaje1 = PlayerPrefs.GetInt("puntaje1");
    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {                        //compara entre los valores de ambos jugadores arrojando al ganador y su puntaje respectivo
        if (puntaje > puntaje1)
        {
            texto.text = "Ganador" + " " + "Jugador1" + " " + "banderas " + puntaje.ToString();
        }
        else if (puntaje == puntaje1)
        {
            texto.text = "Empate" + " " + "banderas " + puntaje.ToString();
        }
        else 
        {
            texto.text = "Ganador" + " " + "Jugador2" + " " + "banderas " + puntaje1.ToString(); 
        }
    }
}
