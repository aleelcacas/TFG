using UnityEngine;

public class MapSpriteSelector : MonoBehaviour
{
    public Sprite spU, spD, spL, spR,
            spUD, spRL, spUR, spUL, spDR, spDL,
            spULD, spRUL, spDRU, spLDR, spUDLR;
    public bool up, down, left, right;

    public int type;

    public Color normalColor, enterColor;

    Color mainColor;

    SpriteRenderer rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rend = GetComponent<SpriteRenderer>();
        mainColor = normalColor;
        PickColor();
        PickSprite();
    }

    void PickSprite(){
        if (up){
            if (down){
                if (right){
                    if (left){
                        rend.sprite = spUDLR;
                    }
                    else{
                        rend.sprite = spDRU;
                    }
                }else if (left){
                    rend.sprite = spULD;
                }
                else{
                    rend.sprite = spUD;
                }
            }else{
                if (right){
                    if (left)
                    {
                        rend.sprite = spRUL;
                    }else{
                        rend.sprite = spUR;
                    }
                }else if (left){
                    rend.sprite = spUL;
                }else{
                    rend.sprite = spU;
                }
            }
            return;   
        }
        if (down){
            if (right){
                if (left){
                    rend.sprite = spLDR;
                }else{
                    rend.sprite = spDR;
                }
            }else if (left){
                rend.sprite = spDL;
            }else{
                rend.sprite = spD;
            }
            return;
        }
        if (right){
            if (left)
            {
                rend.sprite = spRL;
            }else{
                rend.sprite = spR;
            }
        }else{
            rend.sprite = spL;
        }
    }

    void PickColor(){
        if(type == 0) {
            mainColor = normalColor;
        }else if(type == 1){
            mainColor = enterColor;
        }
        rend.color = mainColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
