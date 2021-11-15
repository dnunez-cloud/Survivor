using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//componente del objeto jugador que le da movimiento en los ejes x,y,z
public class MovimientoJugador : MonoBehaviour
{
    private CharacterController character_Controller;         //crea variable para el controlador

    private Vector3 moverDireccion;

    public float velocidad = 10f;
    public float gravedad = 20f;

    public float salto = 10f;
    private float velocidadVertical;

    void Awake()
    {
        character_Controller = GetComponent<CharacterController>();      //asigna componente en la variable
    }
    void Update()
    {
        MoverJugador();
    }

    void MoverJugador()           //función que realiza el movimiento del jugador
    {
       moverDireccion = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")); // Los movimientos del jugador van a transformar su posicion en los ejes X y Z
       moverDireccion = transform.TransformDirection(moverDireccion);

       moverDireccion *= velocidad * Time.deltaTime;   // Se aumenta la velocidad en relacion al tiempo por cuadros por segundo

        AplicarGravedad();

        character_Controller.Move(moverDireccion);
    } 

    void AplicarGravedad()
    {
        if (character_Controller.isGrounded)
        {
            velocidadVertical -= gravedad * Time.deltaTime;

            SaltoJugador();       //función que realizará que el jugador salte
        } 
        else
        {
            velocidadVertical -= gravedad * Time.deltaTime;
        }
        moverDireccion.y = velocidadVertical * Time.deltaTime;         // Aplica gravedad para mantener jugador en el suelo y que no salte 10 metros en el eje Y
    } 

    void SaltoJugador()
    {
        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))   //detecta si el jugador está en el suelo y presiona la tecla de salto
        {
            velocidadVertical = salto;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) // Esta función es para que el jugador produzca impulso en los objetos cuando colisiona con ellos
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        //dont move the rigidbody if the character is on top of it
        if (body == null || body.isKinematic)
        {
            return;
        }
        body.AddForceAtPosition(character_Controller.velocity * 0.1f, hit.point, ForceMode.Impulse);
    }
}
