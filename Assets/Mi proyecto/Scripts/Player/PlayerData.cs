using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    float velocidad;
    int oroRecibido;
    int nivel;
    int ataque;
    int vida;
    int oro;

    public int Nivel
    {
        get
        {
            if (nivel < 1)
            {
                if (!PlayerPrefs.HasKey("Player_Level"))
                {
                    Nivel = 1;
                }

                nivel = PlayerPrefs.GetInt("Player_Level");
            }
            return nivel;
        }
        set
        {
            nivel = value;
            PlayerPrefs.SetInt("Player_Level", nivel);
        }
    }

    public int Ataque
    {
        get
        {
            if (ataque < 1)
            {
                if (!PlayerPrefs.HasKey("Player_Ataque"))
                {
                    Ataque = 1;
                }

                ataque = PlayerPrefs.GetInt("Player_Ataque");
            }
            return ataque;
        }
        set
        {
            ataque = value;
            PlayerPrefs.SetInt("Player_Ataque", ataque);
        }
    }

    public int Vida
    {
        get
        {
            if (vida < 100)
            {
                if (!PlayerPrefs.HasKey("Player_Vida"))
                {
                    Vida = 100;
                }

                vida = PlayerPrefs.GetInt("Player_Vida");
            }
            return vida;
        }
        set
        {
            vida = value;
            PlayerPrefs.SetInt("Player_Vida", vida);
        }
    }

    public int Oro
    {
        get
        {
            if (oro <= 0)
            {
                if (!PlayerPrefs.HasKey("Player_Oro"))
                {
                    Oro = 0;
                }

                oro = PlayerPrefs.GetInt("Player_Oro");
            }
            return oro;
        }
        set
        {
            oro = value;
            PlayerPrefs.SetInt("Player_Oro", oro);
        }
    }

    public int OroRecibido
    {
        get
        {
            if (oroRecibido <= 0)
            {
                if (!PlayerPrefs.HasKey("Player_OroRecibido"))
                {
                    OroRecibido = 0;
                }

                oroRecibido = PlayerPrefs.GetInt("Player_OroRecibido");
            }
            return oroRecibido;
        }
        set
        {
            oroRecibido = value;
            PlayerPrefs.SetInt("Player_OroRecibido", oroRecibido);
        }
    }

    public float extraVelocidad
    {
        get
        {
            if (velocidad <= 0)
            {
                if (!PlayerPrefs.HasKey("Player_Velocidad"))
                {
                    extraVelocidad = 0.75f;
                }

                velocidad = PlayerPrefs.GetFloat("Player_Velocidad");
            }
            return velocidad;
        }
        set
        {
            velocidad = value;
            PlayerPrefs.SetFloat("Player_Velocidad", velocidad);
        }
    }


    public void OnEnable()
    {
        nivel = -1;
        ataque = -1;
        vida = -1;
        oro = -1;
        oroRecibido = -1;
        extraVelocidad = 0.75f;
    }

    public void ResetValuesToCero()
    {
        Nivel = 1;
        Ataque = 1;
        Vida = 100;
        Oro = 0;
        OroRecibido = 1;
        extraVelocidad = 0.75f;
    } 
}
