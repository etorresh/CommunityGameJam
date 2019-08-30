using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject crackedEnemy;
    public float speed;
    public Transform player;
    public Player playerComp;
    public Shoot sh;
    public bool scared;

    public void Hit()
    {
        Instantiate(crackedEnemy, transform.position, transform.rotation);
        playerComp.AddKill();
        Destroy(gameObject);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
