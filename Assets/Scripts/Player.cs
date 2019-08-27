using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveHorizontal;
    private float moveVertical;
    public float moveSpeed = 10;
    public float rotateSpeed = 1;
    private float time;

    private Rigidbody2D rb2;

    void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        time = GetComponent<Renderer>().material.GetFloat("_Vector1_F66CC4A5");
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        float rotate = (Mathf.Clamp((Mathf.Abs(moveVertical) + Mathf.Abs(moveHorizontal)), 0f, 1f) * rotateSpeed) + 1;
        transform.Rotate(new Vector3(0, 0, rotate));


        rb2.AddForce(new Vector2(moveHorizontal, moveVertical) * Time.deltaTime * moveSpeed);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9.2f, 9.2f), Mathf.Clamp(transform.position.y, -5, 5));
    }
}
