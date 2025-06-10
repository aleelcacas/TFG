using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public float MaxHP;
    private float currentHP;
    public Slider vidaSlider;

    void Start()
    {
        currentHP = MaxHP;
    }

    void Update()
    {
        ActualizarVidaUI();
    }

    public void RecibirDaño(float damage)
    {
        currentHP -= damage;
        
        currentHP = Mathf.Clamp(currentHP, 0, MaxHP);

        ActualizarVidaUI();

        if (currentHP <= 0)
        {
            Morir();
        }
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
