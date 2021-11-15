using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Componente de canva ContadorVida para que figure texto con contador de vida del jugador.

public class PantallaVida : MonoBehaviour
{
    public Text texto;
    public Vida vida;

    // Update is called once per frame
    void Update()
    {
        texto.text = vida.valor + "/100";
    }
}
