    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//elemento de los componentes jugador o zombie que contabiliza daño recibido 
//en el jugador también incrementa o decrementa su vida cuando coalisiona con el componente medicina
public class Vida : MonoBehaviour
{
    public float valor = 100;

    public void RecibirDaño(float daño)
    {
        valor -= daño; //resta de la vida el daño recibido
        if (valor < 0) // este if , controla que el valor de vida no sea inferior a cero.
        {
            valor = 0;
        }
    }
    public void incremento(int valore)
    {
        valor += valore; //suma a la vida el valor recibido
    }
}
