using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//componente del elemento arma police 9mm. Controla las balas, sonido, modo dispado y zoom en cámara de disparo(modo ADS). 
//Este script tiene todo el funcionamiento del arma, el raycast del disparo y las animaciones.
public enum ModoDeDisparo
{
    SemiAuto,
    FullAuto
}
public class LogicaArma : MonoBehaviour
{
    protected Animator animator;
    protected AudioSource audioSource;
    public bool tiempoNoDisparo = false;
    public bool puedeDisparar = false;
    public bool recargando = false;
    public bool singravedad = false;

    [Header("Referencia de Objetos")]

    public Camera camaraPrincipal;
    public Transform puntoDeDisparo;
    public Rigidbody rb;                                    //crea variable para cargar el rigidbody del jugador
    public MoverSinGravedad moversingravedad;               //crea variable para asignarle el componente del jugador

    [Header("Referencia de Sonidos")]
    public AudioClip SonDisparo;
    public AudioClip SonSinBalas;
    public AudioClip SonCartuchoEntra;
    public AudioClip SonCartuchoSale;
    public AudioClip SonDesenfundar;
    public AudioClip SonVacio;

    [Header("Atributos de Arma")]
    public ModoDeDisparo modoDeDisparo = ModoDeDisparo.FullAuto;
    public float daño = 20f;
    public float ritmoDeDisparo = 0.3f;
    public int balasRestantes;
    public int balasEnCartucho;
    public int tamañoDeCartucho = 12;
    public int maximoDeBalas = 200;
    public bool estaADS = false;
    public Vector3 disCadera;
    public Vector3 ADS;
    public float tiempoApuntar;
    public float zoom;
    public float normal;
    
    void Awake()
    {
        rb = GameObject.Find("Jugador").GetComponent<Rigidbody>();          //asigna en la variable el componente
    }

    // Start is called before the first frame update
    void Start()
    {                             //asigna los componentes en las variables
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        balasEnCartucho = tamañoDeCartucho;
        balasRestantes = maximoDeBalas;
        Invoke("HabilitarArma", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (modoDeDisparo == ModoDeDisparo.FullAuto && Input.GetButton("Fire1"))  //controla si el jugador está presionando el botón de disparo 
        {
            RevisarDisparo();
        }
        else if (modoDeDisparo == ModoDeDisparo.SemiAuto && Input.GetButtonDown("Fire1"))       //controla si el jugador está presionando el botón de disparo
        {
            RevisarDisparo();
        }
        if (Input.GetButtonDown("Reload"))                           //controla si el jugador presiona el botón para recargar
        {
            RevisarRecargar();
        }
        if (Input.GetMouseButton(1))                      //controla si el jugador presiona el botón para modo ADS
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, ADS, tiempoApuntar * Time.deltaTime); //interpola el vector de posición entre los otros dos vectores
            estaADS = true;
            camaraPrincipal.fieldOfView = Mathf.Lerp(camaraPrincipal.fieldOfView, zoom, tiempoApuntar * Time.deltaTime);  //cambia la visión de la cámara para ver con aumento
        }
        if (Input.GetMouseButtonUp(1))                    //controla si el jugador dejó de presionar el botón para modo ADS
        {
            estaADS = false;
        }
        if (estaADS == false)                            //controla el valor booleano
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, disCadera, tiempoApuntar * Time.deltaTime); //interpola el vector de posición entre los otros dos vectores
            camaraPrincipal.fieldOfView = Mathf.Lerp(camaraPrincipal.fieldOfView, normal, tiempoApuntar * Time.deltaTime); //cambia la visión de la cámara para ver normal
        }
        singravedad = GameObject.Find("Jugador").GetComponent<MoverSinGravedad>().singravedad;    //asigna en la variable el componente
    }

    void HabilitarArma()
    {
        puedeDisparar = true;  //función que cambia el valor booleano de la variable
    }
    void RevisarDisparo()
    {
        if (!puedeDisparar) return;
        if (tiempoNoDisparo) return;
        if (recargando) return;
        if (balasEnCartucho > 0)   //controla que tenga balas en el cartucho
        {
            Disparar();
        }
        else
        {
            SinBalas();
        }
    }
    void Disparar()          //función que reproduce animaciones, sonido del disparo y ejecuta la función DisparoDirecto
    {
        audioSource.PlayOneShot(SonDisparo);
        tiempoNoDisparo = true;

        ReproducirAnimacionDisparo();
        balasEnCartucho--;
        StartCoroutine(ReiniciarTiempoNoDisparo());
        DisparoDirecto();

    }

    void DisparoDirecto()   //función que realiza el hit del disparo, lanzando el evento deseado cuando se topa con uno de los objetos elegidos.
    {
        RaycastHit hit;
            if (Physics.Raycast(puntoDeDisparo.position, puntoDeDisparo.forward, out hit))
            {
                if (hit.transform.CompareTag("Jugador"))                                 //verifica si el raycast impacta con el objeto con ese tag
                {
                    Vida vida = hit.transform.GetComponent<Vida>();                                      //asigna en la varible el componente 
                    if (vida == null)
                    {throw new System.Exception("No se encontró el componente Vida del Enemigo"); }
                    else
                    {vida.RecibirDaño(daño); }                                                             //envía valor al componente 
                }
                if (hit.transform.CompareTag("Enemigo"))
                {
                    Vida vida = hit.transform.GetComponent<Vida>();
                    if (vida == null)
                    {throw new System.Exception("No se encontró el componente Vida del Enemigo"); }
                    else
                    {vida.RecibirDaño(daño);}
                }
                if (hit.transform.CompareTag("Cubo"))
                {
                    Vida vida = hit.transform.GetComponent<Vida>();
                    if (vida == null)
                    { throw new System.Exception("No se encontró el componente Vida del Enemigo");}
                    else
                    { vida.RecibirDaño(daño);}
                }
            }
        if (singravedad == true) { rb.AddForce(5f * -transform.forward); }   // controla el valor booleano y activa el empuje del jugador por el disparo
        else { rb.AddForce(0f * -transform.forward); }
    }
    public virtual void ReproducirAnimacionDisparo()
    {
        if (gameObject.name == "Police9mm")
        {
            if (balasEnCartucho > 1)
            {
                animator.CrossFadeInFixedTime("Fire", 0.1f);
            }
            else
            {
                animator.CrossFadeInFixedTime("FireLast", 0.1f);
            }
        }
        else
        {
            animator.CrossFadeInFixedTime("Fire", 0.1f);
        }
    }
    void SinBalas()           //controla si no tiene balas en cartucho y reproduce audio e inicia co-rutina
    {
        audioSource.PlayOneShot(SonSinBalas);
        tiempoNoDisparo = true;
        StartCoroutine(ReiniciarTiempoNoDisparo());
    }
    IEnumerator ReiniciarTiempoNoDisparo()                    //corutina que optimiza el proceso entre frames
    {
        yield return new WaitForSeconds(ritmoDeDisparo);
        tiempoNoDisparo = false;                                         //cambia el valor booleano de la variable
    }
    void RevisarRecargar()           //función que verifica si tiene balas restantes para recargar en cartucho y a su vez que el cartucho no esté lleno
    {
        if (balasRestantes > 0 && balasEnCartucho < tamañoDeCartucho)
        {
            Recargar();
        }
    }
    void Recargar()                         //función que realiza la secuencia de recarga
    {
        if (recargando) return;
        recargando = true;
        animator.CrossFadeInFixedTime("Reload", 0.1f);
    }
    void RecargarMuniciones()                                               //función que recarga las balas en el cartucho
    {
        int balasParaRecargar = tamañoDeCartucho - balasEnCartucho;                //calcula diferencia entre las balas actuales en cartucho y la capacidad del cartucho
        int restarBalas;
        if (balasRestantes >= balasParaRecargar)
        { restarBalas = balasParaRecargar; }
        else
        { restarBalas= balasRestantes; }

        balasRestantes -= restarBalas;                                      //calcula diferencia restando a las balas totales, las balas usadas para recargar
        balasEnCartucho += balasParaRecargar;                               //completa el cartucho con las balas que le faltaban para estar lleno
    }
    public void DesenfundarOn()
    {
        audioSource.PlayOneShot(SonDesenfundar);
    }
    public void CartuchoEntraOn()
    {
        audioSource.PlayOneShot(SonCartuchoEntra);
        RecargarMuniciones();
    }

    public void CartuchoSaleOn()
    {
        audioSource.PlayOneShot(SonCartuchoSale);
    }
    public void VacioOn()
    {
        audioSource.PlayOneShot(SonVacio);
        Invoke("ReiniciarRecargar", 0.1f);
    }
    void ReiniciarRecargar()                                             //cambia el valor booleano de la variable
    {
        recargando = false;
    }

}

