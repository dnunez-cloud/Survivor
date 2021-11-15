using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//componente del objeto jugador que se activa en zona de gravedad zero para reemplazar los controles del MovimientoJugador
//brindan movimiento al jugador sin gravedad

public class MoverSinGravedad : MonoBehaviour
{
    private CharacterController character_Controller;  //asigna en variable el componente del jugador

    public float velocidadAdelante = 5f, velocidadLateral = 5f;
    public float aceleracionAdelante = 2.5f, aceleracionLateral = 2.5f;
    private float activarVelocidadLateral, activarVelocidadAdelante;

    public bool singravedad = false;              //asigna valor booleano a la variable

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {                          //cargará en la variable el resultado de los productos del axis con la variable y el deltatime
        activarVelocidadAdelante = Mathf.Lerp(activarVelocidadAdelante, Input.GetAxis("Vertical") * velocidadAdelante, aceleracionAdelante * Time.deltaTime);
        activarVelocidadLateral = Mathf.Lerp(activarVelocidadLateral, Input.GetAxis("Horizontal") * velocidadLateral, aceleracionLateral * Time.deltaTime);

        transform.position += transform.forward * activarVelocidadAdelante * Time.deltaTime;
        transform.position += transform.right * activarVelocidadLateral * Time.deltaTime;
    }
}
