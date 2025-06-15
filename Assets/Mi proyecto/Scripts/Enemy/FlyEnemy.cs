using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    private VidaJugador vidaJugador;
    public float damage = 10;
    public float detectionRadius = 10f;
    public float followSpeed = 3f;
    public float idleMoveRadius = 2f;
    public float dashSpeed = 15f;
    public float dashCooldown = 3f;
    public float dashDuration = 0.3f;

    private GameObject player;
    private Animator animator;
    private SpriteRenderer sp;
    private Vector3 randomOffset;
    private float offsetChangeTimer = 0f;
    private float dashCooldownTimer = 0f;
    private float dashTimeLeft = 0f;
    private bool isDashing = false, moving, despertando, agro;
    private Vector3 dashDirection;
    public AudioClip flyEnemySound;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        PickNewOffset();
        agro = false;
        transform.eulerAngles = new Vector3(0, 0, 180);
    }

    void Update()
    {
        animator.SetBool("Moving", moving);

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < detectionRadius)
        {
            agro = true;
        }
        
        if (agro)
        {
            if (despertando == false)
            {
                sp.flipY = false;
                animator.Play("Vueltiña");
                StartCoroutine(CancelarMovimiento());
            }
            else if (despertando == true)
            {
                moving = true;
                if (isDashing)
                {
                    Dash();
                    return;
                }

                offsetChangeTimer -= Time.deltaTime;
                if (offsetChangeTimer <= 0f)
                {
                    PickNewOffset();
                }

                Vector3 targetPos = player.transform.position + randomOffset;
                Vector3 moveDir = (targetPos - transform.position).normalized;
                transform.position += followSpeed * Time.deltaTime * moveDir;
                dashCooldownTimer -= Time.deltaTime;

                if (dashCooldownTimer <= 0f)
                {
                    StartDash();
                }
            }
        }
    }

    IEnumerator CancelarMovimiento()
    {
        yield return new WaitForSeconds(0.49f);
        despertando = true;
    }

    void PickNewOffset()
    {
        randomOffset = new Vector3(Random.Range(-idleMoveRadius, idleMoveRadius), Random.Range(-idleMoveRadius, idleMoveRadius), 0);
        offsetChangeTimer = Random.Range(1f, 2f);
    }

    void StartDash()
    {
        SFX_Manager.instance.PlaySFXClip(flyEnemySound, transform, 1f);
        dashDirection = (player.transform.position - transform.position).normalized;
        isDashing = true;
        dashTimeLeft = dashDuration;
        dashCooldownTimer = dashCooldown;
    }

    void Dash()
    {
        transform.position += dashDirection * dashSpeed * Time.deltaTime;
        dashTimeLeft -= Time.deltaTime;
        if (dashTimeLeft <= 0f)
        {
            isDashing = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isDashing)
        {
            vidaJugador = collision.gameObject.GetComponent<VidaJugador>();

            if (vidaJugador != null)
            {
                vidaJugador.RecibirDaño(damage);
            }
        }
    }
}
