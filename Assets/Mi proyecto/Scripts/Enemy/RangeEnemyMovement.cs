
using System.Collections;
using UnityEngine;

public class RangeEnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private GameObject player;
    public Transform floorDetector, playerDetector, wallDetector;
    public Vector3 rango;
    private Vector3 speed;
    public LayerMask playerLayer, ground, wall;
    private float movDirection;
    bool playerDetected, miroDerecha, floorDetected, wallDetected;
    public float tiempoEntreAtaques = 1f;
    private float tiempoUltimoAtaque = -Mathf.Infinity;
    private bool atacando;
    public GameObject bala;
    public Transform puntoDisparo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        miroDerecha = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (atacando)
            return;
        if (playerDetected)
            {
                VeoJugador();
            }
            else if (!playerDetected)
            {
                Movimiento();
            }
    }

    void FixedUpdate()
    {
        playerDetected = Physics2D.OverlapBox(playerDetector.position, rango, 0, playerLayer);

        floorDetected = Physics2D.OverlapBox(floorDetector.position, new Vector3(1.3f, 0.18f, 0), 0f, ground);

        wallDetected = Physics2D.OverlapBox(wallDetector.position, new Vector3(1, 1, 0), 0f, ground);

        if (!floorDetected && !playerDetected)
        {
            CambiarMovimiento();
        }

        if (wallDetected)
        {
            CambiarMovimiento();
        }
    }

    void Movimiento()
    {
        float mov = movDirection * Time.fixedDeltaTime;
        Vector3 velocidadObjetivo = new Vector2(mov, rb.linearVelocity.y);
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, velocidadObjetivo, ref speed, 0f);

        if (!playerDetected && movDirection == 0)
        {
            if (miroDerecha)
            {
                movDirection = 250;
            }
            else if (!miroDerecha)
            {
                movDirection = -250;
            }
        }
    }

    void CambiarMovimiento()
    {
        if (miroDerecha)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            movDirection = -250;
            miroDerecha = false;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            movDirection = 250;
            miroDerecha = true;
        }
    }

    void VeoJugador()
    {
        if (player.transform.position.x < transform.position.x && miroDerecha)
        {
            CambiarMovimiento();
        }

        else if (player.transform.position.x > transform.position.x && !miroDerecha)
        {
            CambiarMovimiento();
        }
        
        movDirection = 0;

        float distancia = Vector3.Distance(transform.position, player.transform.position);

        if (distancia < 15f)
        {
            rb.linearVelocity = Vector2.zero;
            IniciarAtaque();
        }
        else if (distancia > 10f)
        {
            if (!floorDetected)
            {
                rb.linearVelocity = Vector2.zero;
                return;
            }

            Vector2 direccion = (player.transform.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(direccion.x * 5f, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void IniciarAtaque()
    {
        if (Time.time - tiempoUltimoAtaque < tiempoEntreAtaques)
            return;

        tiempoUltimoAtaque = Time.time;

        animator.Play("EnemigoRangoAttack");
        StartCoroutine(CanlelarMovimiento());
    }

    public void Disparo()
    {
        Instantiate(bala, puntoDisparo.position, puntoDisparo.rotation);
    }

    IEnumerator CanlelarMovimiento()
    {
        atacando = true;
        yield return new WaitForSeconds(0.78f);
        atacando = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(playerDetector.position, rango);
        Gizmos.DrawWireCube(floorDetector.position, new Vector3(1.3f, 0.18f, 0));
        Gizmos.DrawWireCube(wallDetector.position, new Vector3(1f, 1f, 0));
    }  
}
