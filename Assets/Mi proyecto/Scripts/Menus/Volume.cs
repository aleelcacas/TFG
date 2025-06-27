using TMPro;
using UnityEngine;

public class Volume : MonoBehaviour
{
    public TextMeshProUGUI musicaVolActual;
    public PlayerData playerData;
    public TextMeshProUGUI sfxVolActual;
    private float vl1;
    private float vl2;

    void Update()
    {
        vl1 = Mathf.Round(playerData.VolumenMusica * 10) / 10;
        vl2 = Mathf.Round(playerData.VolumenSFX * 10) / 10;
        musicaVolActual.text = "Musica - " + vl1.ToString();
        sfxVolActual.text = "SFX - " + vl2.ToString();
    }
    public void MusicUp()
    {
        if (playerData.VolumenMusica >= 1)
            return;
        playerData.VolumenMusica += 0.1f;
        playerData.VolumenMusica = Mathf.Clamp(playerData.VolumenMusica, 0.0001f, 1f);
    }

    public void MusicDown()
    {
        if (playerData.VolumenMusica <= 0)
            return;
        playerData.VolumenMusica -= 0.1f;
        playerData.VolumenMusica = Mathf.Clamp(playerData.VolumenMusica, 0.0001f, 1f);
    }

    public void SFXUp()
    {
        if (playerData.VolumenSFX >= 1)
            return;
        playerData.VolumenSFX += 0.1f;
        playerData.VolumenSFX = Mathf.Clamp(playerData.VolumenSFX, 0.0001f, 1f);
    }

    public void SFXDown()
    {
        if (playerData.VolumenSFX <= 0)
            return;
        playerData.VolumenSFX -= 0.1f;
        playerData.VolumenSFX = Mathf.Clamp(playerData.VolumenSFX, 0.0001f, 1f);
    }
}
