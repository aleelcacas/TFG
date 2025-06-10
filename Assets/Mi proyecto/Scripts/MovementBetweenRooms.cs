using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementBetweenRooms : MonoBehaviour
{
    public GameObject camara;
    public InteractuarTp interactuarTp;
    private Vector2 posicion, posicionOffset;
    public Animator animator;
    public Vector3 gridPos;

    void OnTriggerEnter2D(Collider2D collision)
    {
        posicion = Vector2.zero;
        posicionOffset = Vector2.zero;

        if (collision.CompareTag("Arriba"))
        {
            interactuarTp.CambiarPosicionEnGrid(new Vector3(0,1,0));
            CambiarSala(0);
        }

        if (collision.CompareTag("Abajo"))
        {
            interactuarTp.CambiarPosicionEnGrid(new Vector3(0,-1,0));
            CambiarSala(1);
        }

        if (collision.CompareTag("Izquierda"))
        {
            interactuarTp.CambiarPosicionEnGrid(new Vector3(-1,0,0));
            CambiarSala(2);
        }

        if (collision.CompareTag("Derecha"))
        {
            interactuarTp.CambiarPosicionEnGrid(new Vector3(1,0,0));
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
                StartCoroutine(AnimacionCamara());
                return;
            case 1:
                posicion = (gridPos + Vector3.down) * new Vector2(96, 52);
                posicionOffset = posicion + new Vector2(0, 10);
                StartCoroutine(AnimacionCamara());
                return;
            case 2:
                posicion = (gridPos + Vector3.left) * new Vector2(96, 52);
                posicionOffset = posicion + new Vector2(21, -2);
                StartCoroutine(AnimacionCamara());
                return;
            case 3:
                posicion = (gridPos + Vector3.right) * new Vector2(96, 52);
                posicionOffset = posicion + new Vector2(-21, -2);
                StartCoroutine(AnimacionCamara());
                return;
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
