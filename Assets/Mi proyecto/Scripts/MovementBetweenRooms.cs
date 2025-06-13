using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementBetweenRooms : MonoBehaviour
{
    public GameObject camara;
    public GameObject[] salas;
    public InteractuarTp interactuarTp;
    private RoomManager roomManager;
    private Vector2 posicion, posicionOffset;
    public Animator animator;
    public Vector3 gridPos;

    void OnTriggerEnter2D(Collider2D collision)
    {
        posicion = Vector2.zero;
        posicionOffset = Vector2.zero;

        salas = GameObject.FindGameObjectsWithTag("Sala");

        if (collision.CompareTag("Arriba"))
        {
            interactuarTp.CambiarPosicionEnGrid(Vector3.up);
            CambiarSala(0);
        }

        if (collision.CompareTag("Abajo"))
        {
            interactuarTp.CambiarPosicionEnGrid(Vector3.down);
            CambiarSala(1);
        }

        if (collision.CompareTag("Izquierda"))
        {
            interactuarTp.CambiarPosicionEnGrid(Vector3.left);
            CambiarSala(2);
        }

        if (collision.CompareTag("Derecha"))
        {
            interactuarTp.CambiarPosicionEnGrid(Vector3.right);
            CambiarSala(3);
        }

    }

    void CambiarSala(int tipoPuerta)
    {
        switch (tipoPuerta)
        {
            case 0:
                posicion = (gridPos + Vector3.up) * new Vector2(96, 52);
                posicionOffset = posicion + new Vector2(-4, -13.5f);
                EntradaSala();
                StartCoroutine(AnimacionCamara());
                return;
            case 1:
                posicion = (gridPos + Vector3.down) * new Vector2(96, 52);
                posicionOffset = posicion + new Vector2(0, 10);
                EntradaSala();
                StartCoroutine(AnimacionCamara());
                return;
            case 2:
                posicion = (gridPos + Vector3.left) * new Vector2(96, 52);
                posicionOffset = posicion + new Vector2(21, -2);
                EntradaSala();
                StartCoroutine(AnimacionCamara());
                return;
            case 3:
                posicion = (gridPos + Vector3.right) * new Vector2(96, 52);
                posicionOffset = posicion + new Vector2(-21, -2);
                EntradaSala();
                StartCoroutine(AnimacionCamara());
                return;
        }
    }

    void EntradaSala()
    {
        GameObject salaObjetivo;
        foreach (GameObject sala in salas)
        {
            if (sala.transform.position == new Vector3(posicion.x, posicion.y, 0))
            {
                salaObjetivo = sala;
                if (sala != null)
                {
                    roomManager = sala.GetComponent<RoomManager>();
                    StartCoroutine(roomManager.JugadorEntra());
                }
            }
            
        }
    }

    IEnumerator AnimacionCamara()
    {
        animator.Play("FundidoNegro");
        yield return new WaitForSeconds(0.5f);
        transform.position = posicionOffset;
        camara.transform.position = posicion;
    }
}
