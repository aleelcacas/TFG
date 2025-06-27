using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHP;
    private bool canTakeDamage;
    private float currentHP;
    public Slider vidaSlider;
    public GameObject muerteUI, vidaOroUI;
    private SpriteRenderer spriteRenderer;
    public PlayerData playerData;
    private Animator animator;
    public AudioClip playerDamaged, playerHeal, playerDieSound;
    public static event Action OnPlayerDie;

    void Start()
    {
        EnemyHealth.OnEnemyDied += Curarse;
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = MaxHP;
        animator = GetComponent<Animator>();
        canTakeDamage = true;
    }

    void OnDestroy()
    {
        EnemyHealth.OnEnemyDied -= Curarse;
    }

    void Update()
    {
        ActualizarVidaUI();
    }

    public void RecibirDaño(float damage)
    {
        if (!canTakeDamage)
            return;

        SFX_Manager.instance.PlaySFXClip(playerDamaged, transform, 1f);
        StartCoroutine(Destello());
        currentHP -= damage;

        currentHP = Mathf.Clamp(currentHP, 0, MaxHP);

        ActualizarVidaUI();

        if (currentHP <= 0)
        {
            Morir();
        }
    }

    IEnumerator Destello()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
    void ActualizarVidaUI()
    {
        if (vidaSlider == null)
            return;
        vidaSlider.value = currentHP / MaxHP;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pocion") && currentHP != MaxHP)
        {
            SFX_Manager.instance.PlaySFXClip(playerHeal, transform, 1f);
            currentHP += 15;
            collision.gameObject.SetActive(false);
        }

    }

    void Curarse(int tipoEnemigo)
    {
        switch (playerData.LifeSteal)
        {
            case 0:
                return;
            case 1:
                currentHP += 5;
                return;
            case 2:
                currentHP += 10;
                return;
        }
    }

    void Morir()
    {
        spriteRenderer.sortingLayerName = "Detalles";
        SFX_Manager.instance.PlaySFXClip(playerDieSound, transform, 1f);
        OnPlayerDie?.Invoke();
        canTakeDamage = false;
        animator.Play("PlayerDie");
        muerteUI.SetActive(true);
        vidaOroUI.SetActive(false);
        PlayerMovement pm = GetComponent<PlayerMovement>();
        PlayerAttack pa = GetComponent<PlayerAttack>();

        pm.enabled = false;
        pa.enabled = false;

        StartCoroutine(VolverMainMenu());
    }

    IEnumerator VolverMainMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}
