using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject crackedEnemy;
    public float speed, stoppingDistance, retreatDistance;
    public Transform player;

    public void Hit()
    {
        Instantiate(crackedEnemy, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) >  stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
