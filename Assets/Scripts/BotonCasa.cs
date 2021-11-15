using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//componente del objeto Rollerball que hace que al colisionar con la puerta, que dice NO PASAR la misma se levante.
public class BotonCasa : MonoBehaviour
{
    public bool valorBool = true;

    public void OnTriggerEnter(Collider ParedL)
    {
        ParedL.GetComponent<ParedLevanta>().incremento(valorBool); //envía el valor de la variable booleana para generar un evento en la función del otro componente
    }
}
