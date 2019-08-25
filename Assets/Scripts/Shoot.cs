using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Vector3 target;
    public GameObject crosshair;
    public GameObject bullet;
    public GameObject bulletGuide;
    public GameObject player;
    public float bulletSpeed = 20;
    public int ammo = 10;
    public float fireRate = 1f;
    public float bulletRotate;
    private float nextFire;

    private bool shoot;

    private Vector3 difference;

    private float mouseX, mouseY;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;

        if(Input.GetMouseButton(0) && ammo != 0 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot = true;
            ammo--;
        }
    }

    void FixedUpdate()
    {
        target = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mouseX, mouseY, transform.position.z));
        target.z = crosshair.transform.position.z;
        crosshair.transform.position = target;

        Vector3 difference = target - bulletGuide.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        bulletGuide.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (shoot)
        {
            print("yeet");
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
   
            GameObject b = Instantiate(bullet, player.transform.position, Quaternion.Euler(0f, 0f, rotationZ)) as GameObject;
            b.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
            b.transform.Rotate(0f, 0f, bulletRotate);

            shoot = false;
        }
    }
}
