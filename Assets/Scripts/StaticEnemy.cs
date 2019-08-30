using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    public GameObject crackedEnemy;
    public Shoot sh;
    public Player playerComp;

    public void Hit()
    {
        Instantiate(crackedEnemy, transform.position, transform.rotation);
        playerComp.AddKill();
        Destroy(gameObject);
    }
}
