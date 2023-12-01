using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public Transform controladorDisparo;
    public float distanciaLinea;
    public LayerMask capaJugador;
    public bool jugadorEnRango;
    public GameObject balaEnemigo;


    public float tiempoEntreDisparo;
    public float tiempoEntreDisparos; 
    public float tiempoEsperaDisparo;


    private Animator animator;

    public float velocidad;
    private Transform jugador;

    private float horizontalInput;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _movement;
    public GameObject BulletPrefab;

    private int Health = 3;
    private float LastShoot;

    private bool MirarndoDerecha = false;

    // public GameObject shooter;
    // Start is called before the first frame update


    private Transform _firePoint;
    private Transform _shootingArea;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        Girar();    
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador == null) return;


        Vector3 direction = jugador.position - transform.position;

        // Ajusta la escala
        if (direction.x >= 0.0f && !MirarndoDerecha)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);
            Girar();
        }
        else if (direction.x < 0.0f && MirarndoDerecha)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);
            Girar();
        }

        jugadorEnRango = Physics2D.Raycast(controladorDisparo.position, controladorDisparo.right, distanciaLinea, capaJugador);

        float distance = Mathf.Abs(jugador.position.x - transform.position.x);

        if (distance <= 1.0f)
        {
            _rigidbody.velocity = Vector2.zero;
            _animator.SetBool("Run", false);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);
            // RotaHaciaJugador();   
            _animator.SetBool("Run", Mathf.Abs(velocidad) > 0);
        }

        if (jugadorEnRango)
        {
            if (Time.time > tiempoEntreDisparos + tiempoEntreDisparo)
            {
                tiempoEntreDisparo = Time.time;
                Invoke(nameof(Disparar), tiempoEsperaDisparo);
                animator.SetTrigger("shoot");
            }
        }
    }

    private void Disparar() 
    {
        Instantiate(balaEnemigo, controladorDisparo.position, controladorDisparo.rotation);
    }

    private void Girar()
    {
        MirarndoDerecha = !MirarndoDerecha;

        if (MirarndoDerecha)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position + transform.right * distanciaLinea);
    }

    public void Hit()
    {
        Health -= 1;
        // Debug.Log(Health);
        if (Health == 0) Destroy(gameObject);
    }
}
