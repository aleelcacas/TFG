using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public PlayerData playerData;
    private SpriteRenderer spriteRenderer;
    public int tipoEnemigo;
    private float MaxHP, maxHpMelee, maxHprango;
    public float currentHP;
    public static event Action<int> OnEnemyDied;
    public AudioClip soltarOroSound;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        VidaMelee();
        VidaRango();

        switch (tipoEnemigo)
        {
            case 0:
                currentHP = maxHpMelee;
                return;
            case 1:
                currentHP = maxHprango;
                return;
            case 2:
                MaxHP = 1;
                currentHP = MaxHP;
                return;
        }
    }

    public void RecibirDaño(float damage)
    {
        StartCoroutine(Destello());
        currentHP -= damage;

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

    void Morir()
    {
        SFX_Manager.instance.PlaySFXClip(soltarOroSound, transform, 0.2f);
        OnEnemyDied?.Invoke(tipoEnemigo);
        Destroy(this.gameObject, 0.1f);
    }

    void VidaMelee()
    {
        if (playerData.Nivel < 5)
        {
            maxHpMelee = 5;
        }
        if (playerData.Nivel >= 5 && playerData.Nivel < 10)
        {
            maxHpMelee = 7;
        }
        if (playerData.Nivel >= 10)
        {
            maxHpMelee = 9;
        }
    }

    void VidaRango()
    {
        if (playerData.Nivel < 5)
        {
            maxHprango = 3;
        }
        if (playerData.Nivel >= 5 && playerData.Nivel < 10)
        {
            maxHprango = 5;
        }
        if (playerData.Nivel >= 10)
        {
            maxHprango = 6;
        }
    }
}
