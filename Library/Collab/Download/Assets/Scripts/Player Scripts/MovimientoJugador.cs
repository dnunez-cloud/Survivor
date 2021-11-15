using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//elemento del componente jugador que se activa en geisser y en zona de gravedad zero para reemplazar los controles del FirstPersonController
public class MovimientoJugador : MonoBehaviour
{
    private CharacterController character_Controller;

    private Vector3 moverDireccion;

    public float velocidad = 5f;
    public float gravedad = 20f;

    public float salto = 10f;
    private float velocidadVertical;

    void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        MoverJugador();
    }

    void MoverJugador()
    {
        // Los movimientos del jugador van a transformar su posicion en los ejes X y Z
       moverDireccion = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

       moverDireccion = transform.TransformDirection(moverDireccion);

        // Se aumenta la velocidad en relacion al tiempo por cuadros por segundo
       moverDireccion *= velocidad * Time.deltaTime;

        AplicarGravedad();

        character_Controller.Move(moverDireccion);
    } //Mueve el jugador

    void AplicarGravedad()
    {
        if (character_Controller.isGrounded)
        {
            velocidadVertical -= gravedad * Time.deltaTime;

            //salto
            SaltoJugador();
        } 
        else
        {
            velocidadVertical -= gravedad * Time.deltaTime;
        }
        moverDireccion.y = velocidadVertical * Time.deltaTime;
    } // Aplica gravedad para mantener jugador en el suelo y que no salte 10metros en el eje Y

    void SaltoJugador()
    {
        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocidadVertical = salto;
        }
    }
}
