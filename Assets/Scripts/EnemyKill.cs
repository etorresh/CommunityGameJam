using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public Player player;
    public bool vulnerable;
    public bool vulnerableMoving;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(vulnerable)
            {
                gameObject.GetComponentInParent<StaticEnemy>().Hit();
                return;
            }
            else if(vulnerableMoving)
            {
                gameObject.GetComponentInParent<Enemy>().Hit();
                return;
            }
            player.StartCoroutine(player.LoseAnimation());
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
