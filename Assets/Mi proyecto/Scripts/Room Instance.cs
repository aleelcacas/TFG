using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class RoomInstance : MonoBehaviour
{
    public Texture2D tex;
    public Vector2 gridPos;
    public int type;
    public bool doorTop, doorBot, doorLeft, doorRight;
    [SerializeField]
    GameObject doorU, doorD, doorL, doorR, doorWall;
    [SerializeField]
    ColorToGameObject[] mappings;
    float tileSize = 16;
    Vector2 roomSizeInTiles = new Vector2 (9,17);


    public  void Setup(Texture2D _tex, Vector2 _gridPos, int _type,
                        bool _doorTop, bool _doorBot, bool _doorLeft, bool _doorRight)
    {
        tex = _tex;
        gridPos = _gridPos;
        type = _type;
        doorTop = _doorTop;
        doorBot = _doorBot;
        doorLeft = _doorLeft;
        doorRight = _doorRight;
        MakeDoors();
        GenerateRoomTiles();
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
    void GenerateRoomTiles()
    {
        for(int x = 0; x < tex.width; x++)
        {
            for(int y = 0; y < tex.height; y++)
            {
                GenerateTile(x,y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = tex.GetPixel(x,y);
        if(pixelColor.a == 0)
        {
            return;
        }
        foreach(ColorToGameObject mapping in mappings)
        {
            if(mapping.color.Equals(pixelColor))
            {
                Vector3 spawPos = positionFromTileGrid(x,y);
                Instantiate(mapping.prefab, spawPos, Quaternion.identity).transform.parent = this.transform;
            }
            else
            {
                print(mapping.color + "," + pixelColor);
            }
        }
    }

    Vector3 positionFromTileGrid(int x, int y)
    {
        Vector3 ret;
        Vector3 offset = new Vector3((-roomSizeInTiles.x + 1)*tileSize, (roomSizeInTiles.y/4)* tileSize - (tileSize/4), 0);

        ret = new Vector3(tileSize * (float) x, -tileSize * (float) y, 0) + offset + transform.position;
        return ret;
    }
}
