using UnityEngine;

public class SheetAssignerCopia : MonoBehaviour
{
    [SerializeField] 
    GameObject[] sheetsNormal;
    [SerializeField]
    GameObject RoomObj;
    public Vector2 roomDimensions = new Vector2(16*17, 16*9);
    public Vector2 gutterSize = new Vector2(16*9, 16*4);

    public void Assign(Room[,] rooms)
    {
        foreach (Room room in rooms)
        {
            if (room == null)
            {
                continue;
            }
            int index = Random.Range(0, 3);
            Vector3 pos = new Vector3(room.gridPos.x * (roomDimensions.x + gutterSize.x),
                                        room.gridPos.y * (roomDimensions.y + gutterSize.y), 0);
            RoomInstanceCopia myRoom = Instantiate(RoomObj, pos, Quaternion.identity).GetComponent<RoomInstanceCopia>();
            myRoom.Setup(sheetsNormal[index], room.gridPos, room.type, room.doorTop, room.doorBot, room.doorLeft, room.doorRight);
        }
    }
}
