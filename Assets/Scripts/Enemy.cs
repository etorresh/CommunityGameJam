using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject crackedEnemy;

    public void Hit()
    {
        Instantiate(crackedEnemy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
