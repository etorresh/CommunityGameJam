using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveHorizontal;
    private float moveVertical;
    public float moveSpeed = 10;
    public float rotateSpeed = 1;
    private float timeDead = 0;
    public bool dead = false;
    public Shoot sh;

    private Rigidbody2D rb2;

    public CameraPos camPos;

    void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    public IEnumerator LoseAnimation()
    {
        moveSpeed = 0;
        rotateSpeed = 0;
        sh.ammo = 0;
        dead = true;
        camPos.transition = true;

        while (true)
        {
            if (timeDead < 1)
            {
                timeDead += 0.010f;
                GetComponent<Renderer>().material.SetFloat("_Vector1_F66CC4A5", timeDead);
                yield return new WaitForSeconds(0.05f);
            }
            else
            {
                yield return null;
            }
        }
    }

    void FixedUpdate()
    {
        float rotate = (Mathf.Clamp((Mathf.Abs(moveVertical) + Mathf.Abs(moveHorizontal)), 0f, 1f) * rotateSpeed) + 1;
        transform.Rotate(new Vector3(0, 0, rotate));


        rb2.AddForce(new Vector2(moveHorizontal, moveVertical) * Time.deltaTime * moveSpeed);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9.2f, 9.2f), Mathf.Clamp(transform.position.y, -5, 5));
    }
}
