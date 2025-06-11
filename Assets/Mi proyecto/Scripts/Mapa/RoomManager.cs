using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemigos = new List<GameObject>();
    GameObject[] salas;
    public GameObject sala;
    Vector3 gridPos;
    public bool salaTermianda, doorTop, doorBot, doorLeft, doorRight;
    public GameObject doorUpOpen, doorBotOpen, doorRightOpen, doorLeftOpen;

    void Start()
    {
        DondeEstoy();
    }

    public void Referencias(bool _doorTop, bool _doorBot, bool _doorLeft, bool _doorRight, Vector2 _gridPos)
    {
        doorTop = _doorTop;
        doorBot = _doorBot;
        doorLeft = _doorLeft;
        doorRight = _doorRight;
        gridPos = new Vector3(_gridPos.x * 96, _gridPos.y * 52, 0);
    }

    void Update()
    {
        if (salaTermianda)
            return;

        enemigos.RemoveAll(e => e == null);

        if (enemigos.Count == 0)
        {
            TerminarSala();
            salaTermianda = true;
        }
    }

    void DondeEstoy()
    {
        salas = GameObject.FindGameObjectsWithTag("RoomRoot");

        foreach (GameObject obj in salas)
        {
            if (obj.transform.position == gridPos)
            {
                sala = obj;
            }
        }
    }

    void TerminarSala()
    {
        if (doorTop)
        {
            Transform puertaArriba = sala.transform.Find("CloseDoorUp(Clone)");
            Instantiate(doorUpOpen, puertaArriba.transform.position, Quaternion.identity);
            Destroy(puertaArriba.gameObject);
            doorTop = false;
        }

        if (doorBot)
        {
            Transform puertaAbajo = sala.transform.Find("CloseDoorDown(Clone)");
            Instantiate(doorBotOpen, puertaAbajo.transform.position, Quaternion.identity);
            Destroy(puertaAbajo.gameObject);
            doorBot = false;
        }

        if (doorLeft)
        {
            Transform puertaIzquierda = sala.transform.Find("CloseDoorLeft(Clone)");
            Instantiate(doorLeftOpen, puertaIzquierda.transform.position, Quaternion.identity);
            Destroy(puertaIzquierda.gameObject);
            doorLeft = false;
        }

        if (doorRight)
        {
            Transform puertaDerecha = sala.transform.Find("CloseDoorRight(Clone)");
            Instantiate(doorRightOpen, puertaDerecha.transform.position, Quaternion.identity);
            Destroy(puertaDerecha.gameObject);
            doorRight = false;
        }
    }
}
