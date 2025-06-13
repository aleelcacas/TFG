using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class RoomInstanceCopia : MonoBehaviour
{
    public GameObject prefab;
    public Vector2 gridPos;
    public int type;
    public bool doorTop, doorBot, doorLeft, doorRight;
    [SerializeField]
    GameObject doorU, doorD, doorL, doorR, wallUp, wallDown, wallSides;


    public void Setup(GameObject _prefab, Vector2 _gridPos,
                        bool _doorTop, bool _doorBot, bool _doorLeft, bool _doorRight)
    {
        prefab = _prefab;
        gridPos = _gridPos;
        doorTop = _doorTop;
        doorBot = _doorBot;
        doorLeft = _doorLeft;
        doorRight = _doorRight;
        RoomManager roomManager = Instantiate(prefab, transform.position, Quaternion.identity).GetComponent<RoomManager>();
        roomManager.Referencias(doorTop, doorBot, doorLeft, doorRight, gridPos);
        MakeDoors();
    }
    void MakeDoors()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, 15, 0);
        PlaceDoor(spawnPos, doorTop, doorU, wallUp);
        spawnPos = transform.position + new Vector3(0, -15, 0);
        PlaceDoor(spawnPos, doorBot, doorD, wallDown);
        spawnPos = transform.position + new Vector3(24, 0, 0);
        PlaceDoor(spawnPos, doorRight, doorR, wallSides);
        spawnPos = transform.position + new Vector3(-24, 0, 0);
        PlaceDoor(spawnPos, doorLeft, doorL, wallSides);
    }

    void PlaceDoor(Vector3 spawnPos, bool door, GameObject doorSpawn, GameObject wallSpawn)
    {
        if (door)
        {
            Instantiate(doorSpawn, spawnPos, Quaternion.identity).transform.parent = transform;
        }
        else
        {
            Instantiate(wallSpawn, spawnPos, Quaternion.identity).transform.parent = transform;
        }
    }
}
