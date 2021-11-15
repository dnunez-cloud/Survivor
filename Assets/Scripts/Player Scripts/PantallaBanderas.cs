using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Componente de canva ContadorPuntaje para que figure texto con contador de banderas del Jugador.
public class PantallaBanderas : MonoBehaviour
{
    public Text texto;
    public LogicaPuntaje logicaPuntaje;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        texto.text = "Banderas: " + logicaPuntaje.puntajeJugador;
    }
}
