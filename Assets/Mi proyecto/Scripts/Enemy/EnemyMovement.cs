using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private MeleeAttack meleeAttack;
    private bool playerDetected, floorDetected, miroDerecha, wallDetected;
    public LayerMask ground, playerLayer, wall;
    public Transform floorDetector, playerDetector, wallDetector;
    private GameObject player;
    public int movDirection;
    public float velocidad;
    private Vector3 speed;
    public Vector3 tamano;
    private Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        meleeAttack = GetComponent<MeleeAttack>();
        playerDetected = false;
        miroDerecha = true;
        velocidad = 5f;
    }

    void Update()
    {
        animator.SetFloat("MovSpeed", rb.linearVelocityX);

        if (meleeAttack.atacando)
            return;
        if (!playerDetected)
            {
                Movimiento();
            }
            else
            {
                Enfadado();
            }
    }

    void FixedUpdate()
    {
        floorDetected = Physics2D.OverlapBox(floorDetector.position, new Vector3(1.3f, 0.18f, 0), 0f, ground);

        playerDetected = Physics2D.OverlapBox(playerDetector.position, tamano, 0f, playerLayer);

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
                movDirection = 300;
            }
            else if (!miroDerecha)
            {
                movDirection = -300;
            }
        }
    }

    void CambiarMovimiento()
    {
        if (miroDerecha)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            movDirection = -300;
            miroDerecha = false;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            movDirection = 300;
            miroDerecha = true;
        }
    }

    void Enfadado()
    {
        movDirection = 0;

        float distancia = Vector3.Distance(transform.position, player.transform.position);

        animator.SetFloat("Distancia", distancia);

        if (distancia < 2.5f)
        {
            rb.linearVelocity = Vector2.zero;
            meleeAttack.IniciarAtaque();
        }
        else if (distancia > 2.5f)
        {
            if (!floorDetected)
            {
                rb.linearVelocity = Vector2.zero;
                return;
            }

            Vector2 direccion = (player.transform.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(direccion.x * velocidad, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(floorDetector.position, new Vector3(1.3f, 0.18f, 0));
        Gizmos.DrawWireCube(playerDetector.position, tamano);
        Gizmos.DrawWireCube(wallDetector.position, new Vector3(1f, 1f, 0));
    }
}
