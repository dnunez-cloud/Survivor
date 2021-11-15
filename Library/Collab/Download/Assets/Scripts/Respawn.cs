using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//componente del elemento Jugador que hará respawn cuando el jugador se cae del mapa o cuando su vida llega a 0
public class Respawn : MonoBehaviour
{
    public Transform respawn;
    public Transform posicionJugador;
    public Vida vida;
    public int penalidad = 1;
    // Update is called once per frame
    void Update()
    {
        if (JugadorCaido())
        {
            Respawnear();
            gameObject.GetComponent<LogicaPuntaje>().incremento(-penalidad);
        }
        if (vida.valor <=0)
        {
            CharacterController cc = GetComponent<CharacterController>();
            cc.enabled = false;
            posicionJugador.transform.position = respawn.transform.position;
            cc.enabled = true; vida.valor = 100;
            gameObject.GetComponent<LogicaPuntaje>().incremento(-penalidad);
            gameObject.GetComponent<LogicaJugador>().vida0= false;
        }
    }

    public void Respawnear()
    {
        //debido a un bug de unity en FPS charactercontroller, al hacer respawn se deshabilitaba el charactercontroller, por lo cual hay que reinicializarlo
        CharacterController cc = GetComponent<CharacterController>();
        cc.enabled = false;
        posicionJugador.transform.position = respawn.transform.position;
        cc.enabled = true;

    }

    private bool JugadorCaido()
    {
        return posicionJugador.position.y < -0.5;
    }
}
