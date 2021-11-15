﻿    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//elemento de los componentes jugador o zombie que contabiliza daño recibido 
//en el jugador también incrementa o decrementa su vida cuando coalisiona con el componente medicina
public class Vida : MonoBehaviour
{
    public float valor = 100;

    public void RecibirDaño(float daño)
    {
        valor -= daño;
        if (valor < 0)
        {
            valor = 0;
        }
    }
    public void incremento(int valore)
    {
        valor += valore;
    }
}
