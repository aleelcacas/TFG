using Unity.Mathematics;
using UnityEngine;

public class balaRotacionPrueba : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direccion = new Vector2(player.transform.position.x, player.transform.position.y) - new Vector2(transform.position.x, transform.position.y);

        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angulo);

        float angulo1 = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
    }
}
