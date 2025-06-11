using System.Collections;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData playerData;
    private PlayerAttack playerAttack;
    private Rigidbody2D rb;
    private Animator animator;
    public GameObject currentOneWayPlatform;
    public CapsuleCollider2D playerColldier;
    private float movSpeed = 600, movSmooth = 0.15f, movX, jumpForce = 250;
    private Vector3 speed;
    public Vector3 detectorSize;
    public Transform floorDetector;
    public bool suelado, mirandoDerecha;
    public bool vortereta;
    public LayerMask ground, player, enemy, nada;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
        vortereta = true;
    }

    void Update()
    {
        movX = InputManager.instance.MoveInput.x * movSpeed;

        animator.SetFloat("velocidad",rb.linearVelocity.x);
        
        if (!vortereta)
            return;
        
        PaDondeMiro();

        if (InputManager.instance.JumpPressed && InputManager.instance.MoveInput.y == -1)
        {
            if (currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
            else if (suelado)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

        else if (suelado && InputManager.instance.JumpPressed)
        { 
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        else if (InputManager.instance.DashPressed && vortereta)
        {
            vortereta = false;
            StartCoroutine(Vortereta());
        }
    }

    void FixedUpdate()
    {
        suelado = Physics2D.OverlapBox(floorDetector.position, detectorSize, 0f, ground);

        if (!vortereta)
            return;

        if (playerAttack.atacando)
            return;
        Mover();

        if (suelado)
        {
            animator.SetBool("saltando", false);
        }
        if (!suelado)
        {
            animator.SetBool("saltando", true);
            if (rb.linearVelocityY > 0)
                animator.Play("PlayerJump");
            if (rb.linearVelocityY < 0)
                animator.Play("PlayerFall");
        }
    }

    IEnumerator Vortereta()
    {
        playerColldier.excludeLayers = enemy;

        transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);

        rb.gravityScale = 0;

        if(!mirandoDerecha)
        {
            rb.linearVelocity = new Vector2(17, 0);
        }
        else if(mirandoDerecha)
        {
            rb.linearVelocity = new Vector2(-17, 0);
        }
        
        yield return new WaitForSeconds(0.35f);

        PonerGravedad();

        playerColldier.excludeLayers = nada;
        
        transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
        
        vortereta = true;
    }

    void PaDondeMiro()
    {
        if (InputManager.instance.MoveInput.x == 1)
        {
            mirandoDerecha = false;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (InputManager.instance.MoveInput.x == -1)
        {
            mirandoDerecha = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void Mover()
    {
        float mov = movX * Time.deltaTime * playerData.extraVelocidad;
        Vector3 velocidadObjetivo = new Vector2(mov, rb.linearVelocityY);
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, velocidadObjetivo, ref speed, movSmooth);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(floorDetector.position, detectorSize);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    public void PonerGravedad()
    {
        rb.gravityScale = 5;
    }
    IEnumerator DisableCollision()
    {
        BoxCollider2D[] platformCollider = currentOneWayPlatform.GetComponents<BoxCollider2D>();

        foreach (BoxCollider2D hit in platformCollider)
        {
            Physics2D.IgnoreCollision(playerColldier, hit);
        }
        
        yield return new WaitForSeconds(0.4f);

        foreach (BoxCollider2D hit in platformCollider)
        {
            Physics2D.IgnoreCollision(playerColldier, hit, false);
        }
        
    }
}
