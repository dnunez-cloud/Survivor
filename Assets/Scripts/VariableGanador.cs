using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//elemento del componente gameobject vacío que almacena las banderas obtenidas por los jugadores para enviarlo a la escena Fin de la partida.
public class VariableGanador : MonoBehaviour
{
    public int puntaje;
    public int puntaje1;
    public LogicaPuntaje logicaPuntaje;
    public LogicaPuntaje logicaPuntaje1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntaje = logicaPuntaje.puntajeJugador; //carga en la variable el puntaje del jugador 1
        puntaje1 = logicaPuntaje1.puntajeJugador; //carga en la variable el puntaje del jugador 2
        PlayerPrefs.SetInt("puntaje", puntaje); //setea en prefs el puntaje del jugador 1 para guardarlo
        PlayerPrefs.SetInt("puntaje1", puntaje1); //setea en prefs el puntaje del jugador 2 para guardarlo
        PlayerPrefs.Save(); // guarda ambos puntajes.
    }
    void Awake()
    {
        DontDestroyOnLoad(this); //evita que el objeto se destruya en el cambio de escena
    }
}
