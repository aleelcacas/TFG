using System;
using UnityEngine;

public class SheetAssigner : MonoBehaviour
{
    [SerializeField] 
    Texture2D[] sheetsNormal;
    [SerializeField]
    GameObject RoomObj;
    public Vector2 roomDimensions = new Vector2(16*17, 16*9);
    public Vector2 gutterSize = new Vector2(16*9, 16*4);

    public void Assign(Room[,] rooms)
    {
        foreach(Room room in rooms)
        {
            if(room == null)
            {
                continue;
            }
            int index = Mathf.RoundToInt((sheetsNormal.Length -1));
            Vector3 pos = new Vector3(room.gridPos.x * (roomDimensions.x + gutterSize.x),
                                        room.gridPos.y * (roomDimensions.y + gutterSize.y), 0);
            RoomInstance myRoom = Instantiate(RoomObj, pos, Quaternion.identity).GetComponent<RoomInstance>();
            myRoom.Setup(sheetsNormal[index], room.gridPos, room.type, room.doorTop, room.doorBot, room.doorLeft, room.doorRight);
        }
    }
}
