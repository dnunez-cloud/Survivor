using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//componente del objeto portal que reacciona a la coalisión con el jugador
//Le da un valor que va a interactuar con el script portal que está en el jugador y cambia su posición
public class ObjPortal : MonoBehaviour
{
    private int valorP = 1;

    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Portal>().incremento(valorP); //Cuando el jugador colisiona con el objeto, se enviará el valor cargado en la variable para ocasionar un evento
    }
}
