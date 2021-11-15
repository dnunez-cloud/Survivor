using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Componente de canva ContadorBalas para que figuren texto con contador de balas y municiones del jugador.
public class PantallaBalas2 : MonoBehaviour
{
    public Text texto;
    public LogcaArma2 logicaArma;  //asigna en la variable el componente

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        texto.text = logicaArma.balasEnCartucho + "/" + logicaArma.tamañoDeCartucho //toma los parámetros dentro del componente y los expresa en pantalla
        + "\n" + logicaArma.balasRestantes;
    }
}

