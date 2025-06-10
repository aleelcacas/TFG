using System;
using UnityEditor;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemigos;
    bool salaTermianda, doorTop, doorBot, doorLeft, doorRight;
    public GameObject doorUpOpen, doorBotOpen, doorRightOpen, doorLeftOpen;

    void Start()
    {

    }

    public void Referencias(bool _doorTop, bool _doorBot, bool _doorLeft, bool _doorRight)
    {
        doorTop = _doorTop;
        doorBot = _doorBot;
        doorLeft = _doorLeft;
        doorRight = _doorRight;
    }

    void Update()
    {
        if (salaTermianda)
            return;
        if (enemigos.Length == 0)
        {
            TerminarSala();
            salaTermianda = true;
        }

        foreach (GameObject enemigo in enemigos)
        {
            if (enemigo == null)
            {
                ArrayUtility.Remove(ref enemigos, enemigo);
                break;
            }
        }
    }

    void TerminarSala()
    {
        
    }
}
