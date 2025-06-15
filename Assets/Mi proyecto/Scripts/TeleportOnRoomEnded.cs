using Unity.VisualScripting;
using UnityEngine;

public class TeleportOnRoomEnded : MonoBehaviour
{
    Vector3 posicionEnGrid;
    Vector3 posicionTp;
    GameObject player, camara;
    InteractuarTp interactuarTp;
    public AudioClip playerTPSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        interactuarTp = player.GetComponent<InteractuarTp>();
    }

    public void SetPosicion(Vector3 gridPos)
    {
        posicionEnGrid = gridPos;
    }

    public void TeleporPlayer()
    {
        SFX_Manager.instance.PlaySFXClip(playerTPSound, transform, 1f);
        interactuarTp.CloseTeleporUI();
        posicionTp = new Vector3(posicionEnGrid.x * 96, posicionEnGrid.y * 52);
        player.transform.position = new Vector2(posicionTp.x -23, posicionTp.y -14);
        camara.transform.position = posicionTp;
        interactuarTp.posicionActualGrid = posicionEnGrid;
    }
}
