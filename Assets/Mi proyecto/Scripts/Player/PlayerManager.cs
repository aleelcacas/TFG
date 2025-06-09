using UnityEngine;
using TMPro;
public class PlayerManager : MonoBehaviour
{
    public PlayerData playerData;
    public TextMeshProUGUI oroText, nivelText, vidaText, ataquetext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VidaEnemigo.OnEnemyDied += RecibirOro;
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarUI();
    }

    void ActualizarUI()
    {
        oroText.text = "Oro = " + playerData.Oro.ToString();
        nivelText.text = "Nivel Jugador = " + playerData.Nivel.ToString();
        vidaText.text = "Vida Maxima = " + playerData.Vida.ToString();
        ataquetext.text = "Daño Ataque = " + playerData.Ataque.ToString();
    }

    void RecibirOro(int tipoEnemigo)
    {
        switch (tipoEnemigo)
        {
            case 0:
                playerData.Oro += 10 + (playerData.OroRecibido * 3);
                return;
            case 1:
                playerData.Oro += 8 + (playerData.OroRecibido * 2);
                return;
            case 2:
                playerData.Oro += 5 + playerData.OroRecibido;
                return;
        }
    }
}
