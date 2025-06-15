using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private Animator animator;
    private VidaJugador vidaJugador;
    public PlayerData playerData;
    public float tiempoEntreAtaques = 1f;
    private float tiempoUltimoAtaque = -Mathf.Infinity;
    public bool atacando;
    public LayerMask playerLayer;
    public Transform puntoGolpe;
    public Vector2 tamañoGolpe = new Vector2(1.5f, 1f);
    public int damage;
    public AudioClip meleeAttackSound;
    void Start()
    {
        animator = GetComponent<Animator>();
        damage += playerData.Nivel * 2;
        if (damage > 40)
            damage = 40;
    }
    public void IniciarAtaque()
    {
        if (Time.time - tiempoUltimoAtaque < tiempoEntreAtaques)
            return;
        tiempoUltimoAtaque = Time.time;
        animator.Play("EnemyMeleeAttack");

        StartCoroutine(CanlelarMovimiento());
    }

    IEnumerator CanlelarMovimiento()
    {
        atacando = true;
        yield return new WaitForSeconds(1);
        atacando = false;
    }
    public void RealizarGolpe()
    {
        SFX_Manager.instance.PlaySFXClip(meleeAttackSound, transform, 1f);
        Collider2D jugador = Physics2D.OverlapBox(puntoGolpe.position, tamañoGolpe, 0f, playerLayer);
        if (jugador == null)
            return;
        vidaJugador = jugador.gameObject.GetComponent<VidaJugador>();
        if (jugador != null)
        {
            vidaJugador.RecibirDaño(damage);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(puntoGolpe.position, tamañoGolpe);
    }
}
