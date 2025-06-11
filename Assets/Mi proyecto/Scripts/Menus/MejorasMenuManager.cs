using TMPro;
using UnityEngine;

public class MejorasMenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoAtaque, textoVida, textoVelocidad, textoOro, oroActual, textoMapSize, textoLifeSteal;
    [SerializeField] private TextMeshProUGUI textoCosteAtaque, textoCosteVida, textoCosteVelocidad, textoCosteOro, textoCosteMapa, textoCosteLifeSteal;
    private int costeMejoraAtaque, costeMejoraVida, costeMejoraOro, costeMejoraVelocidad, costeMejoraMapa, costeMejoraLifeSteal;

    public PlayerData playerData;

    public void LevelUpAtaque()
    {
        if (playerData.Oro < costeMejoraAtaque)
            return;
        if (playerData.Ataque == 3)
            return;
        playerData.Ataque += 1;
        playerData.Oro -= costeMejoraAtaque;
        playerData.Nivel += 1;
    }

    public void LevelUpVida()
    {
        if (playerData.Oro < costeMejoraVida)
            return;
        if (playerData.Vida == 200)
            return;
        playerData.Vida += 25;
        playerData.Oro -= costeMejoraVida;
        playerData.Nivel += 1;
    }

    public void LevelUpVelocidad()
    {
        if (playerData.Oro < costeMejoraVelocidad)
            return;
        if (playerData.extraVelocidad == 1.5f)
            return;
        playerData.extraVelocidad += 0.25f;
        playerData.Oro -= costeMejoraVelocidad;
        playerData.Nivel += 1;
    }

    public void LevelUpOro()
    {
        if (playerData.Oro < costeMejoraOro)
            return;
        if (playerData.OroRecibido == 4)
            return;
        playerData.OroRecibido += 1;
        playerData.Oro -= costeMejoraOro;
        playerData.Nivel += 1;
    }

    public void LevelUpMapSize()
    {
        if (playerData.Oro < costeMejoraMapa)
            return;
        if (playerData.MapSize == 3)
            return;
        playerData.MapSize += 1;
        playerData.Oro -= costeMejoraMapa;
        playerData.Nivel += 1;
    }

    public void LevelUpLifeSteal()
    {
        if (playerData.Oro < costeMejoraLifeSteal)
            return;
        if (playerData.LifeSteal == 3)
            return;
        playerData.LifeSteal += 1;
        playerData.Oro -= costeMejoraLifeSteal;
        playerData.Nivel += 1;
    }

    void Update()
    {
        oroActual.text = playerData.Oro.ToString();

        Ataque();
        Vida();
        Oro();
        Velocidad();
        MapSize();
        LifeSteal();
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
            case 1:
                costeMejoraOro = 50;
                textoCosteOro.text = costeMejoraOro.ToString();
                textoOro.text = "Oro Recibido Nv. 1";
                return;
            case 2:
                costeMejoraOro = 100;
                textoCosteOro.text = costeMejoraOro.ToString();
                textoOro.text = "Oro Recibido Nv. 2";
                return;
            case 3:
                costeMejoraOro = 150;
                textoCosteOro.text = costeMejoraOro.ToString();
                textoOro.text = "Oro Recibido Nv. 3";
                return;
            case 4:
                costeMejoraOro = 250;
                textoCosteOro.text = costeMejoraOro.ToString();
                textoOro.text = "Oro Recibido Nv. 4";
                return;
            case 5:
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

    void MapSize()
    {
        switch (playerData.MapSize)
        {
            case 1:
                costeMejoraMapa = 50;
                textoCosteMapa.text = costeMejoraMapa.ToString();
                textoMapSize.text = "MapSize Nv. 1";
                return;
            case 2:
                textoCosteMapa.text = costeMejoraMapa.ToString();
                textoMapSize.text = "MapSize Nv. 2";
                costeMejoraMapa = 150;
                return;
            case 3:
                textoCosteMapa.text = costeMejoraMapa.ToString();
                textoMapSize.text = "MapSize Nv. Máximo";
                return;
        }
    }

    void LifeSteal()
    {
        switch (playerData.LifeSteal)
        {
            case 1:
                costeMejoraLifeSteal = 150;
                textoCosteLifeSteal.text = costeMejoraLifeSteal.ToString();
                textoLifeSteal.text = "LifeSteal Nv. 0";
                return;
            case 2:
                costeMejoraLifeSteal = 300;
                textoCosteLifeSteal.text = costeMejoraLifeSteal.ToString();
                textoLifeSteal.text = "LifeSteal Nv. 1";
                return;
            case 3:
                textoCosteLifeSteal.text = costeMejoraLifeSteal.ToString();
                textoLifeSteal.text = "LifeSteal Nv. Máximo";
                return;
        }
    }
}
