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
    GameObject doorU, doorD, doorL, doorR, doorWall;
    float tileSize = 16;
    Vector2 roomSizeInTiles = new Vector2 (9,17);


    public  void Setup(GameObject _prefab, Vector2 _gridPos, int _type,
                        bool _doorTop, bool _doorBot, bool _doorLeft, bool _doorRight)
    {
        prefab = _prefab;
        gridPos = _gridPos;
        type = _type;
        doorTop = _doorTop;
        doorBot = _doorBot;
        doorLeft = _doorLeft;
        doorRight = _doorRight;
        Instantiate(prefab, transform.position, Quaternion.identity);
        MakeDoors();
    }
    void MakeDoors()
    {
        Vector3 spawnPos = transform.position + Vector3.up*(roomSizeInTiles.y/4 * tileSize) - Vector3.up*(tileSize/4);
        PlaceDoor(spawnPos, doorTop, doorU);
        spawnPos = transform.position + Vector3.down*(roomSizeInTiles.y/4 * tileSize) - Vector3.down*(tileSize/4);
        PlaceDoor(spawnPos, doorBot, doorD);
        spawnPos = transform.position + Vector3.right*(roomSizeInTiles.y/2 * tileSize) - Vector3.right*(8);
        PlaceDoor(spawnPos, doorRight, doorR);
        spawnPos = transform.position + Vector3.left*(roomSizeInTiles.y/2 * tileSize) - Vector3.left*(8);
        PlaceDoor(spawnPos, doorLeft, doorL);
    }

    void PlaceDoor(Vector3 spawnPos, bool door, GameObject doorSpawn)
    {
        if(door)
        {
            Instantiate(doorSpawn, spawnPos, Quaternion.identity).transform.parent = transform;
        }
        else
        {
            Instantiate(doorWall, spawnPos, Quaternion.identity).transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
