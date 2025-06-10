using UnityEngine;

public class BalaMovement : MonoBehaviour
{
    public float velocidad = 15f;
    public float tiempoVida = 5f;
    public float damage = 15f;
    private Vector3 direccion;
    private Vector3 rotacion;

    void Start()
    {
        Destroy(this.gameObject, 6);
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");

        if (jugador != null)
        {
            direccion = (jugador.transform.position - transform.position).normalized;
            direccion += new Vector3(0, 0.2f, 0);
            transform.eulerAngles = jugador.transform.position.normalized;
        }

        Vector2 rotacion = new Vector2(jugador.transform.position.x, jugador.transform.position.y) - new Vector2(transform.position.x, transform.position.y);

        float angulo = Mathf.Atan2(rotacion.y + 0.2f, rotacion.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }

    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime;
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            VidaJugador vidaJugador = collision.gameObject.GetComponent<VidaJugador>();
            vidaJugador.RecibirDaño(damage);
            Destroy(this.gameObject);
        }   
    }
}
