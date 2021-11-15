using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//componente del elemento medicina, incrementará o decrementará la vida del player cuando colisiona con este objeto.
public class Medicina : MonoBehaviour
{
    public int valorMed = 0; //variable que cargará el valor indicado en cada objeto para incrementar o decrementar vida

    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Vida>().incremento(valorMed); //enviará el valor cargado en la variable valorMed cuando el jugador colisiona con el objeto
        Destroy(gameObject); //destruye el objeto luego de la colisión
    }
}
