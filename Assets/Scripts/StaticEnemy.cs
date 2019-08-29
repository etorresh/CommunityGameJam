using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    public GameObject crackedEnemy;
    public Shoot sh;

    public void Hit()
    {
        sh.ammo += 1;
        Instantiate(crackedEnemy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
