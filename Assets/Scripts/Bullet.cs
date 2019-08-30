using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Hit();
        }
        else if (collision.gameObject.CompareTag("StaticEnemy"))
        {
            collision.gameObject.GetComponent<StaticEnemy>().Hit();
        }
        Destroy(gameObject);
    }
}
