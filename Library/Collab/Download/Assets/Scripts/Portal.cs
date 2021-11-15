using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//elemento del componente jugador que detecta cuando coalisionó con el gameobject portal y hace que se transforme su posición
public class Portal : MonoBehaviour
{
    public Transform portal;
    public int valor;
    public Transform posicionJugador;

    // Update is called once per frame
    void Update()
    {
        if (valor== 1)
        {
            Mover();
            valor = 0;
        }
        
    }
    public void incremento(int valorP)
    {
        valor = valorP;
    }
    public void Mover()
    {
        //debido a un bug de unity en FPS charactercontroller, al hacer respawn se deshabilitaba el charactercontroller, por lo cual hay que reinicializarlo
        CharacterController cc = GetComponent<CharacterController>();
        cc.enabled = false;
        posicionJugador.transform.position = portal.transform.position;
        cc.enabled = true;

    }
}
