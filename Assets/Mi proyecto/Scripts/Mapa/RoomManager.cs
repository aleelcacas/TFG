using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemigos = new List<GameObject>();
    GameObject[] salas;
    public GameObject sala;
    GameObject player;
    Vector3 gridPos;
    public bool salaTermianda, doorTop, doorBot, doorLeft, doorRight;
    public GameObject doorUpOpen, doorBotOpen, doorRightOpen, doorLeftOpen, tpObject, pocion;

    void Start()
    {
        DondeEstoy();
        foreach (GameObject enemigo in enemigos)
        {
            enemigo.SetActive(false);
        }

         if (gridPos == Vector3.zero)
            StartCoroutine(JugadorEntra());
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
            tpObject.SetActive(true);
            pocion.SetActive(true);
            TerminarSala();
            CambioSpriteMapa();
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

    void CambioSpriteMapa()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        InteractuarTp interactuarTp = player.GetComponent<InteractuarTp>();

        interactuarTp.ActivarTp();
    }

    public IEnumerator JugadorEntra()
    {
        yield return new WaitForSeconds(1);
        foreach (GameObject enemigo in enemigos)
        {
            enemigo.SetActive(true);
        }
    }
}
