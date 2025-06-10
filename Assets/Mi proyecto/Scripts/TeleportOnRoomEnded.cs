using Unity.VisualScripting;
using UnityEngine;

public class TeleportOnRoomEnded : MonoBehaviour
{
    Vector3 posicionEnGrid;
    Vector3 posicionTp;
    GameObject player, camara;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camara = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void SetPosicion(Vector3 gridPos)
    {
        posicionEnGrid = gridPos;
    }

    public void TeleporPlayer()
    {
        posicionTp = new Vector3(posicionEnGrid.x * 416, posicionEnGrid.y * 208);
        player.transform.position = posicionTp;
        camara.transform.position = posicionTp;
    }
}
