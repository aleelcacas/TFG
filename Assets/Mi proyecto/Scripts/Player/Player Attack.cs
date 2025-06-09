using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerData playerData;
    public int damage;
    public bool atacando;
    private Rigidbody2D rb;
    private Animator animator;
    public LayerMask enemy;
    public Vector2 tamañoGolpe = new Vector2(1.5f, 1f);
    public Transform puntoGolpe;
    private VidaEnemigo vidaEnemigo;
    private PlayerMovement playerMovement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        atacando = false;
    }

    void Update()
    {
        damage = playerData.Ataque;
        if (!playerMovement.vortereta)
            return;
        if (InputManager.instance.AttackPressed && !atacando)
            {
                atacando = true;
                StartCoroutine(Ataque());
            }
        if (atacando)
            return;
    }


    IEnumerator Ataque()
    {
        animator.Play("PlayerAttack");
        rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
        yield return new WaitForSeconds(0.6f);
        atacando = false;
    }
    public void HacerDaño()
    {
        Collider2D enemigo = Physics2D.OverlapBox(puntoGolpe.position, tamañoGolpe, 0f, enemy);
        if (enemigo == null)
            return;
        vidaEnemigo = enemigo.gameObject.GetComponent<VidaEnemigo>();

        vidaEnemigo.RecibirDaño(playerData.Ataque);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(puntoGolpe.position, tamañoGolpe);
    }
}
