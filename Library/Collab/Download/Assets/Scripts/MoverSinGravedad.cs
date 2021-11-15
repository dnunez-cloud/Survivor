using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//elemento del componente jugador que se activa en zona de gravedad zero para reemplazar los controles del FirstPersonController
//hacer que el personaje vuele como un helicoptero con movimiento en los 3 ejes

public class MoverSinGravedad : MonoBehaviour
{
    private CharacterController character_Controller;

    public float velocidadAdelante = 15f, velocidadLateral = 7.5f, velocidadFlotar = 5f;
    private float activarVelocidadAdelante, activarVelocidadLateral, activarVelocidadFlotar;
    private float aceleracionAdelante = 2.5f, aceleracionLateral = 2f, aceleracionFlotar = 2f;

    private float miraRotarVelocidad = 30f;
    public Vector2 miraInput, centroPantalla, mouseDistancia;

    private float rollInput;
    private float rollVelocidad = 9f, rollAcelaracion = 3.5f;
    public bool singravedad= false;



    void Start()
    {
        centroPantalla.x = Screen.width * .5f;
        centroPantalla.y = Screen.height * .5f;

      //  Cursor.lockState = CursorLockMode.Confined; 
    }

    // Update is called once per frame
    void Update()
    {
        miraInput.x = Input.mousePosition.x;
        miraInput.y = Input.mousePosition.y;

        mouseDistancia.x = (miraInput.x - centroPantalla.x) / centroPantalla.y;
        mouseDistancia.y = (miraInput.y - centroPantalla.y) / centroPantalla.y;

        mouseDistancia = Vector2.ClampMagnitude(mouseDistancia, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxis("Roll"), rollAcelaracion * Time.deltaTime);

        transform.Rotate(-mouseDistancia.y * miraRotarVelocidad * Time.deltaTime, mouseDistancia.x * miraRotarVelocidad * Time.deltaTime, rollInput * rollVelocidad * Time.deltaTime , Space.Self);

        activarVelocidadAdelante = Mathf.Lerp(activarVelocidadAdelante ,Input.GetAxis("Vertical") * velocidadAdelante, aceleracionAdelante * Time.deltaTime);
        activarVelocidadLateral = Mathf.Lerp( activarVelocidadLateral,Input.GetAxis("Horizontal") * velocidadLateral, aceleracionLateral * Time.deltaTime);
        activarVelocidadFlotar = Mathf.Lerp(activarVelocidadFlotar,Input.GetAxis("Hover") * velocidadFlotar, velocidadFlotar * Time.deltaTime);

        transform.position += transform.forward * activarVelocidadAdelante * Time.deltaTime;
        transform.position += (transform.right * activarVelocidadLateral * Time.deltaTime) + (transform.up * activarVelocidadFlotar * Time.deltaTime);
        

    }
}
