using UnityEngine;
using TMPro;
public class PlayerManager : MonoBehaviour
{
    public PlayerData playerData;
    public TextMeshProUGUI oroText, nivelText, vidaText, ataquetext, velocidadText, oroRecibidoText, mapaText, lifeStealText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VidaEnemigo.OnEnemyDied += RecibirOro;
    }

    void OnDestroy()
    {
        VidaEnemigo.OnEnemyDied -= RecibirOro;
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
        oroRecibidoText.text = "Oro Recibido = Nv." + playerData.OroRecibido.ToString();
        mapaText.text = "Tamaño Mapa = Nv." + playerData.MapSize.ToString();
        ActualizarVelocidadUI();
        ActualizarLifeStealUI();
    }

    void ActualizarVelocidadUI()
    {
        switch (playerData.extraVelocidad)
        {
            case 0.75f:
                velocidadText.text = "Velocidad = Nv.1";
                return;
            case 1f:
                velocidadText.text = "Velocidad = Nv.2";
                return;
            case 1.25f:
                velocidadText.text = "Velocidad = Nv.3";
                return;
            case 1.5f:
                velocidadText.text = "Velocidad = Nv.4";
                return;
        }
    }

    void ActualizarLifeStealUI()
    {
        switch (playerData.LifeSteal)
        {
            case 1:
                lifeStealText.text = "Robo de Vida = Nv.0";
                return;
            case 2:
                lifeStealText.text = "Robo de Vida = Nv.1";
                return;
            case 3:
                lifeStealText.text = "Robo de Vida = Nv.2";
                return;
        }
    }

    void RecibirOro(int tipoEnemigo)
    {
        switch (tipoEnemigo)
        {
            case 0:
                if (playerData.OroRecibido <= 1)
                {
                    playerData.Oro += 10;
                }
                else
                {
                    playerData.Oro += 10 + (playerData.OroRecibido * 3);
                }
                return;
            case 1:
                if (playerData.OroRecibido <= 1)
                {
                    playerData.Oro += 8;
                }
                else
                {
                    playerData.Oro += 8 + (playerData.OroRecibido * 2);
                }
                return;
            case 2:
                if (playerData.OroRecibido <= 1)
                {
                    playerData.Oro += 5;
                }
                else
                {
                    playerData.Oro += 5 + playerData.OroRecibido;
                }
                return;
        }
    }
}
