using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//componente del objeto zombie, funciona dandole vida al mismo, para que localice al jugador, lo persiga y lo ataque.
public class LogicaEnemigo : MonoBehaviour

{
    private GameObject jugadorcerca;
    private NavMeshAgent agente;
    private Vida vida;
    private Animator animator;
    private Collider collider;
    private Vida vidaJugador;
    private LogicaJugador logicaJugador;
    public bool vida0 = false;
    public bool estaAtacando = false;
    public float speed = 1.0f;
    public float angularSpeed = 120;
    public float daño = 25;
    public bool mirando;
    // Start is called before the first frame update
    void Start()
    {                                             //asigna los componentes a las variables cuando comienza el juego
        agente = GetComponent<NavMeshAgent>();
        vida = GetComponent<Vida>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();              //función que controla la vida del enemigo para detectar cuando el mismo ya no posee vida.
        BuscarJugadorCerca();      //función que registra y compara la distancia entre ambos jugadores
        RevisarAtaque();          //función que revisa si se cumplen todas las condiciones para realizar el ataque
        EstaDeFrenteAlJugador(); //función que controla si el enemigo está de frente al jugador
    }
   void BuscarJugadorCerca()  //función que registra y compara la distancia entre ambos jugadores
    {
        GameObject[] objetivos;                                    //primero crea variable con un array para cargar ambos jugadores
        objetivos = GameObject.FindGameObjectsWithTag("Jugador"); //se cargan ambos objetos jugador en el array
        float distance = Mathf.Infinity;                          // crea una variable para que busque en todo el escenario los gameobjects
        Vector3 position = transform.position;                          //carga la posición actual del objeto enemigo
        foreach (GameObject objetivo in objetivos)                     //analiza cada objeto dentro del array
        {
            Vector3 diff = objetivo.transform.position - position;       //calculará la diferencia entre la posición del objeto Jugador y la posición el enemigo
            float curDistance = diff.sqrMagnitude;                     //asignará el resultado obtenido en el vector anterior en distancia cuadrada, a una variable curDistance
            if (curDistance < distance)                                 //compara la distancia de la variable anterior con la variable que tiene el rango completo
            {
                jugadorcerca = objetivo;                                 //asignará al gameObject jugadorcerca el elemento del array que resultó mas cercano
                distance = curDistance;                                    //asignará a la variable distance el nuevo parámetro para comparar 
            }
        }
        Perseguir();                               //Función que hace que el enemigo persiga al jugador (que es el mas cercano)
    }
    void EstaDeFrenteAlJugador()                   //función que controla si el enemigo está de frente al jugador
    {
        Vector3 adelante = transform.forward;                                                       //vector que carga el punto de posición adelante
        Vector3 targetJugador = (jugadorcerca.transform.position - transform.position).normalized; //vector que carga el resultado entre la posición del jugador y el enemigo
        if (Vector3.Dot(adelante, targetJugador) < 0.6f)        //compara un valor con el resultado del producto de los dos vectores por el conseno del ángulo entre ellos
        {
            mirando = false;              //cambiará el valor de la variable booleana
        }
        else
        {
            mirando = true;
        }
    }
    void RevisarVida()                           //función que controla la vida del enemigo para detectar cuando el mismo ya no posee vida.
    {
        if (vida0) return;
        if (vida.valor <= 0)                     //compara el valor de vida del enemigo y desencadena el evento si llegó a cero
        {
            vida0 = true;
            agente.isStopped = true;
            collider.enabled = false;
            animator.CrossFadeInFixedTime("vida0", 0.1f);
            Destroy(gameObject, 3f);  
        }
    }
    void Perseguir()                                      //Función que hace que el enemigo persiga al jugador (que es el mas cercano)
    {
        if (vida0) return;
        logicaJugador = jugadorcerca.GetComponent<LogicaJugador>();                    //carga en la variable el parámetro del jugador cercano
        if (logicaJugador.vida0) return;
        float rangoAtaque = Vector3.Distance(jugadorcerca.transform.position, transform.position);    //carga en variable, la distancia entre el jugador cercano y el enemigo
        if (rangoAtaque > 60) { return; }                                                          //compara la variable con un campo deseado y si es inferior desencadena evento
        else
        {
            agente.destination = jugadorcerca.transform.position;                        //asigna al destino del enemigo la posición del jugador
        }
    }
    void RevisarAtaque()                                      //función que revisa si se cumplen todas las condiciones para realizar el ataque
    {
        if (vida0) return;
        if (estaAtacando) return;
        if (logicaJugador.vida0) return;
        float distanciaDelBlanco = Vector3.Distance(jugadorcerca.transform.position, transform.position); //carga en variable, la distancia entre el jugador cercano y el enemigo
        if (distanciaDelBlanco <= 2.0 && mirando)                               //compara la variable con dos condiciones que si se cumplen desencadena función de atacar
        {
            Atacar();                                              //Función que ejecuta el ataque del enemigo al jugador
        }
    }
    void Atacar()
    {
        vidaJugador = jugadorcerca.GetComponent<Vida>();    //carga en variable el componente vida del jugador
        vidaJugador.RecibirDaño(daño);                      //de la variable anterior enviará el daño al componente
        agente.speed = 0;
        agente.angularSpeed = 0;
        estaAtacando = true;
        animator.SetTrigger("DebeAtacar");
        Invoke("ReiniciarAtaque", 1.5f);
    }
    void ReiniciarAtaque()                             //función que seguirá ejecutando los ataques mientras se sigan cumpliendo las condiciones
    {
        estaAtacando = false;
        agente.speed = speed;
        agente.angularSpeed = angularSpeed;
    }
}
