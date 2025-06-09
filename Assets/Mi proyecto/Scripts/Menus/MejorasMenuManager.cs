using TMPro;
using UnityEngine;

public class MejorasMenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoAtaque, textoVida, textoVelocidad, textoOro, oroActual;
    [SerializeField] private TextMeshProUGUI textoCosteAtaque, textoCosteVida, textoCosteVelocidad, textoCosteOro;
    private int costeMejoraAtaque, costeMejoraVida, costeMejoraOro, costeMejoraVelocidad;

    public PlayerData playerData;

    public void LevelUpAtaque()
    {
        if (playerData.Oro < costeMejoraAtaque)
            return;
        if (playerData.Ataque == 3)
            return;
        playerData.Ataque += 1;
        playerData.Oro -= costeMejoraAtaque;
    }

    public void LevelUpVida()
    {
        if (playerData.Oro < costeMejoraVida)
            return;
        if (playerData.Vida == 200)
            return;
        playerData.Vida += 25;
        playerData.Oro -= costeMejoraVida;
    }

    public void LevelUpVelocidad()
    {
        if (playerData.Oro < costeMejoraVelocidad)
            return;
        if (playerData.extraVelocidad == 1.5f)
            return;
        playerData.extraVelocidad += 0.25f;
        playerData.Oro -= costeMejoraVelocidad;
    }

    public void LevelUpOro()
    {
        if (playerData.Oro < costeMejoraOro)
            return;
        if (playerData.OroRecibido == 4)
            return;
        playerData.OroRecibido += 1;
        playerData.Oro -= costeMejoraOro;
    }

    void Update()
    {
        oroActual.text = playerData.Oro.ToString();

        Ataque();
        Vida();
        Oro();
        Velocidad();
    }

    void Ataque()
    {
        switch (playerData.Ataque)
        {
            case 1:
                costeMejoraAtaque = 100;
                textoCosteAtaque.text = costeMejoraAtaque.ToString();
                textoAtaque.text = "Ataque Nv. 1";
                return;
            case 2:
                costeMejoraAtaque = 200;
                textoCosteAtaque.text = costeMejoraAtaque.ToString();
                textoAtaque.text = "Ataque Nv. 2";
                return;
            case 3:
                textoCosteAtaque.text = "Nv. Máximo";
                textoAtaque.text = "Ataque Nv. 3";
                return;
        }
    }

    void Vida()
    {
        switch (playerData.Vida)
        {
            case 100:
                costeMejoraVida = 50;
                textoCosteVida.text = costeMejoraVida.ToString();
                textoVida.text = "Vida Nv. 1";
                return;
            case 125:
                costeMejoraVida = 75;
                textoCosteVida.text = costeMejoraVida.ToString();
                textoVida.text = "Vida Nv. 2";
                return;
            case 150:
                costeMejoraVida = 100;
                textoCosteVida.text = costeMejoraVida.ToString();
                textoVida.text = "Vida Nv. 3";
                return;
            case 175:
                costeMejoraVida = 200;
                textoCosteVida.text = costeMejoraVida.ToString();
                textoVida.text = "Vida Nv. 4";
                return;
            case 200:
                textoCosteVida.text = "Nv. Máximo";
                textoVida.text = "Vida Nv. 5";
                return;
        }
    }

    void Oro()
    {
        switch (playerData.OroRecibido)
        {
            case 0:
                costeMejoraOro = 50;
                textoCosteOro.text = costeMejoraOro.ToString();
                textoOro.text = "Oro Recibido Nv. 1";
                return;
            case 1:
                costeMejoraOro = 100;
                textoCosteOro.text = costeMejoraOro.ToString();
                textoOro.text = "Oro Recibido Nv. 2";
                return;
            case 2:
                costeMejoraOro = 150;
                textoCosteOro.text = costeMejoraOro.ToString();
                textoOro.text = "Oro Recibido Nv. 3";
                return;
            case 3:
                costeMejoraOro = 250;
                textoCosteOro.text = costeMejoraOro.ToString();
                textoOro.text = "Oro Recibido Nv. 4";
                return;
            case 4:
                textoCosteOro.text = "Nv. Máximo";
                textoOro.text = "Oro Recibido Nv. 5";
                return;
        }
    }

    void Velocidad()
    {
        switch (playerData.extraVelocidad)
        {
            case 0.75f:
                costeMejoraVelocidad = 100;
                textoCosteVelocidad.text = costeMejoraVelocidad.ToString();
                textoVelocidad.text = "Velocidad Nv. 1";
                return;
            case 1f:
                costeMejoraVelocidad = 200;
                textoCosteVelocidad.text = costeMejoraVelocidad.ToString();
                textoVelocidad.text = "Velocidad Nv. 2";
                return;
            case 1.25f:
                costeMejoraVelocidad = 300;
                textoCosteVelocidad.text = costeMejoraVelocidad.ToString();
                textoVelocidad.text = "Velocidad Nv. 3";
                return;
            case 1.5f:
                textoCosteVelocidad.text = "Nv. Máximo";
                textoVelocidad.text = "Velocidad Nv. 4";
                return;
        }
    }
}
