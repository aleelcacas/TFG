using Unity.VisualScripting;
using UnityEngine;

public class PlayerDieCamera : MonoBehaviour
{
    GameObject player;
    bool playerDead;
    Animator animator;
    void Start()
    {
        playerDead = false;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        VidaJugador.OnPlayerDie += ZoomPlayer;
    }

    void OnDestroy()
    {
        VidaJugador.OnPlayerDie -= ZoomPlayer;
    }

    void ZoomPlayer()
    {
        playerDead = true;
        animator.Play("ZoomCamara");
    }

    void Update()
    {
        if (playerDead)
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.05f); Debug.Log("veoalplayer");
    }
}
