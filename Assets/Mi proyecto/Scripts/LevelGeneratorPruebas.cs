using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class LevelGeneratoPruebas : MonoBehaviour
{
    Room[,] rooms;
    List<Vector2> takenPositions = new List<Vector2>();
    int gridSizeX, gridSizeY, numberOfRooms;
    public GameObject roomWhiteObj;
    public Vector2 inicio;
    public Transform mapRoot;
    int numerodesalas;
    public PlayerData playerData;

    void Start()
    {
        gridSizeX = 5;
        gridSizeY = 4;
        NumeroSalas();

        numberOfRooms = numerodesalas;

        CreateRooms();
        SetRoomDoors();
        DrawMap();
        GetComponent<SheetAssignerCopia>().Assign(rooms);
    }

    void NumeroSalas()
    {
        switch (playerData.MapSize)
        {
            case 1:
                numerodesalas = Random.Range(8, 17);
                return;
            case 2:
                numerodesalas = Random.Range(10, 21);
                return;
            case 3:
                numerodesalas = Random.Range(16, 23);
                return;
        }
        
    }

    void CreateRooms()
    {
        rooms = new Room[gridSizeX * 2, gridSizeY * 2];
        rooms[gridSizeX, gridSizeY] = new Room(inicio, 1);
        takenPositions.Insert(0, inicio);
        Vector2 checkPos;

        for (int i = 0; i < numberOfRooms - 1; i++)
        { 
            checkPos = NewPosition();
            if (NumberOfNeighbors(checkPos, takenPositions) > 1)
            {
                int iterations = 0;
                do
                {
                    checkPos = SelectiveNewPosition();
                    iterations++;
                } while (NumberOfNeighbors(checkPos, takenPositions) > 1 && iterations < 20);
            }

            if ((int)checkPos.x >= 0)
            {
                rooms[(int)checkPos.x + gridSizeX, (int)checkPos.y + gridSizeY] = new Room(checkPos, 0);
                takenPositions.Insert(0, checkPos);
            }
            else i--;
        }
    }

    Vector2 NewPosition()
    {
        int x, y;
        Vector2 checkingPos;

        do
        {
            int index = Mathf.RoundToInt(Random.value * (takenPositions.Count - 1));
            
            x = (int)takenPositions[index].x;
            y = (int)takenPositions[index].y;
            
            bool UpDown = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);

            if (UpDown){
                if (positive){
                    y += 1;
                }else{
                    y -= 1;
                }
            }
            else{
                if (positive){
                    x += 1;
                }else{
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y);
        }while (takenPositions.Contains(checkingPos) || x >= gridSizeX || x < -gridSizeX || y >= gridSizeY || y < -gridSizeY);
        return checkingPos;
    }

    Vector2 SelectiveNewPosition()
    {
        int index, inc;
        int x, y;
        Vector2 checkingPos;
        do
        {
            inc = 0;
            
            do
            {
                index = Mathf.RoundToInt(Random.value * (takenPositions.Count - 1));
                inc++;
            } while (NumberOfNeighbors(takenPositions[index], takenPositions) > 1 && inc < 100);
            
            x = (int)takenPositions[index].x;
            y = (int)takenPositions[index].y;
            bool UpDown = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);
            if (UpDown){
                if (positive){
                    y += 1;
                }else{
                    y -= 1;
                }
            }else{
                if (positive){
                    x += 1;
                }else{
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y);
        }while (takenPositions.Contains(checkingPos) || x >= gridSizeX || x < -gridSizeX || y >= gridSizeY || y < -gridSizeY);
        if (inc >= 100)
        {
            print("Error: no se han encontrado posiciones con menos de un vecino");
        }
        return checkingPos;
    }

    int NumberOfNeighbors(Vector2 checkingPos, List<Vector2> usedPositions)
    {
        int ret = 0;
        if (usedPositions.Contains(checkingPos + Vector2.right))
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.left))
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.up))
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.down))
        {
            ret++;
        }
        return ret;
    }
    void SetRoomDoors()
    {
        for (int x = 0; x < (gridSizeX * 2); x++)
        {
            for (int y = 0; y < (gridSizeY * 2); y++)
            {
                if (rooms[x, y] == null)
                {
                    continue;
                }
                if (y - 1 < 0)
                {
                    rooms[x, y].doorBot = false;
                }
                else
                {
                    rooms[x, y].doorBot = rooms[x, y - 1] != null;
                }
                if (y + 1 >= gridSizeY * 2)
                {
                    rooms[x, y].doorTop = false;
                }
                else
                {
                    rooms[x, y].doorTop = rooms[x, y + 1] != null;
                }
                if (x - 1 < 0)
                {
                    rooms[x, y].doorLeft = false;
                }
                else
                {
                    rooms[x, y].doorLeft = rooms[x - 1, y] != null;
                }
                if (x + 1 >= gridSizeX * 2)
                {
                    rooms[x, y].doorRight = false;
                }
                else
                {
                    rooms[x, y].doorRight = rooms[x + 1, y] != null;
                }
            }
        }
    }

    void DrawMap()
    {
        foreach (Room room in rooms)
        {
            if (room == null)
            {
                continue;
            }

            Vector2 drawPos = room.gridPos;
            drawPos.x *= 130;
            drawPos.y *= 70;
            MapSpriteSelectorMap mapper = Instantiate(roomWhiteObj, drawPos, Quaternion.identity).GetComponent<MapSpriteSelectorMap>();
            mapper.gridPos = room.gridPos;
            mapper.up = room.doorTop;
            mapper.down = room.doorBot;
            mapper.left = room.doorLeft;
            mapper.right = room.doorRight;
            mapper.gameObject.transform.parent = mapRoot;
        }
    }
}

