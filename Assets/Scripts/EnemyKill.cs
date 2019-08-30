using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public Player player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.StartCoroutine(player.LoseAnimation());
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
