using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerEscaleras : MonoBehaviour
{
    public float movY, velocidadEscalera;
    private bool escalera, escalando;
    public PlayerMovement playerMovement;

    public Rigidbody2D playerRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movY = Input.GetAxis("Vertical");
        
        if(escalera && Math.Abs(movY) > 0f)
        {
            escalando = true;
        }
    }

    void FixedUpdate()
    {
        if(escalando)
        {
            playerRb.gravityScale = 0f;
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, movY * velocidadEscalera);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Escalera"))
        {
            escalera = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Escalera"))
        {
            escalera = false;
            escalando = false;
            playerMovement.PonerGravedad();
        }
    }
}
