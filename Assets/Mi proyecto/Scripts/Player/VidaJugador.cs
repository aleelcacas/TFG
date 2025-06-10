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

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = MaxHP;
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

    void Morir()
    {

    }
}
