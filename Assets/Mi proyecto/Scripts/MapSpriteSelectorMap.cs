using UnityEngine;
using UnityEngine.UI;

public class MapSpriteSelectorMap : MonoBehaviour
{
    public Sprite spU, spD, spL, spR,
            spUD, spRL, spUR, spUL, spDR, spDL,
            spULD, spRUL, spDRU, spLDR, spUDLR;
    public bool up, down, left, right;

    public int type;
    public Vector2 gridPos;
    Image rend;
    TeleportOnRoomEnded teleportOnRoomEnded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Image>();
        teleportOnRoomEnded = GetComponent<TeleportOnRoomEnded>();
        PickSprite();
        SetPositionReference();
        transform.localPosition = gridPos * new Vector2(220, 110) + new Vector2(540, 0);
    }

    void PickSprite()
    {
        if (up)
        {
            if (down)
            {
                if (right)
                {
                    if (left)
                    {
                        rend.sprite = spUDLR;
                    }
                    else
                    {
                        rend.sprite = spDRU;
                    }
                }
                else if (left)
                {
                    rend.sprite = spULD;
                }
                else
                {
                    rend.sprite = spUD;
                }
            }
            else
            {
                if (right)
                {
                    if (left)
                    {
                        rend.sprite = spRUL;
                    }
                    else
                    {
                        rend.sprite = spUR;
                    }
                }
                else if (left)
                {
                    rend.sprite = spUL;
                }
                else
                {
                    rend.sprite = spU;
                }
            }
            return;
        }
        if (down)
        {
            if (right)
            {
                if (left)
                {
                    rend.sprite = spLDR;
                }
                else
                {
                    rend.sprite = spDR;
                }
            }
            else if (left)
            {
                rend.sprite = spDL;
            }
            else
            {
                rend.sprite = spD;
            }
            return;
        }
        if (right)
        {
            if (left)
            {
                rend.sprite = spRL;
            }
            else
            {
                rend.sprite = spR;
            }
        }
        else
        {
            rend.sprite = spL;
        }
    }

    void SetPositionReference()
    {
        teleportOnRoomEnded.SetPosicion(gridPos);
    }
}
