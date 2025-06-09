using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementBetweenRooms : MonoBehaviour
{
    public GameObject camara;
    public InteractuarTp interactuarTp;
    private RoomInstanceCopia roomInstance;
    private Vector2 posicion, posicionOffset;
    public Animator animator;
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        roomInstance = null;
        posicion = Vector2.zero;
        posicionOffset = Vector2.zero;

        if (collision.CompareTag("Arriba"))
        {
            roomInstance = collision.GetComponentInParent<RoomInstanceCopia>();
            interactuarTp.CambiarPosicionEnGrid(new Vector3(0,1,0));
            CambiarSala(0);
        }

        if (collision.CompareTag("Abajo"))
        {
            roomInstance = collision.GetComponentInParent<RoomInstanceCopia>();
            interactuarTp.CambiarPosicionEnGrid(new Vector3(0,-1,0));
            CambiarSala(1);
        }

        if (collision.CompareTag("Izquierda"))
        {
            roomInstance = collision.GetComponentInParent<RoomInstanceCopia>();
            interactuarTp.CambiarPosicionEnGrid(new Vector3(-1,0,0));
            CambiarSala(2);
        }

        if (collision.CompareTag("Derecha"))
        {
            roomInstance = collision.GetComponentInParent<RoomInstanceCopia>();
            interactuarTp.CambiarPosicionEnGrid(new Vector3(1,0,0));
            CambiarSala(3);
        }

    }

    void CambiarSala(int tipoPuerta)
    {
        switch (tipoPuerta)
        {
            case 0:
                posicion = (roomInstance.gridPos + Vector2.up) * new Vector2(416, 208);
                posicionOffset = posicion + new Vector2(17, -54);
                StartCoroutine(AnimacionCamara());
                return;
            case 1:
                posicion = (roomInstance.gridPos + Vector2.down) * new Vector2(416, 208);
                posicionOffset = posicion + new Vector2(0, 38);
                StartCoroutine(AnimacionCamara());
                return;
            case 2:
                posicion = (roomInstance.gridPos + Vector2.left) * new Vector2(416, 208);
                posicionOffset = posicion + new Vector2(111, -6);
                StartCoroutine(AnimacionCamara());
                return;
            case 3:
                posicion = (roomInstance.gridPos + Vector2.right) * new Vector2(416, 208);
                posicionOffset = posicion + new Vector2(-111, -6);
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
