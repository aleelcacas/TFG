using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public float MaxHP;
    private float currentHP;
    public Slider vidaSlider;
    private SpriteRenderer spriteRenderer;
    public PlayerData playerData;

    void Start()
    {
        VidaEnemigo.OnEnemyDied += Curarse;
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = MaxHP;
    }

    void OnDestroy()
    {
        VidaEnemigo.OnEnemyDied -= Curarse;
    }

    void Update()
    {
        ActualizarVidaUI();
    }

    public void RecibirDaño(float damage)
    {
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
            currentHP += 10;
            collision.gameObject.SetActive(false);
        }
            
    }

    void Curarse(int tipoEnemigo)
    {
        switch (playerData.LifeSteal)
        {
            case 1:
                return;
            case 2:
                currentHP += 5;
                return;
            case 3:
                currentHP += 10;
                return;
        }
    }

    void Morir()
    {

    }
}
