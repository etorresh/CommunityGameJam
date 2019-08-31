using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    private Vector3 target;
    public CameraPos cPos;
    public Player playerComp;
    public GameObject crosshair;
    public GameObject bullet;
    public GameObject bulletGuide;
    public GameObject player;
    public float bulletSpeed = 20;
    public int ammo = 1;
    public float fireRate = 1f;
    public float bulletRotate;
    public float recoilForce = 1f;
    private float nextFire;
    public bool needsAmmo;
    public bool stop;
    private bool checkActive;

    public Text ammoCounter;

    private bool shoot;

    private Vector3 difference;

    private float mouseX, mouseY;

    private void Start()
    {
        Cursor.visible = false;
        playerComp = player.GetComponent<Player>();
    }

    private void Update()
    {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;

        if(Input.GetMouseButton(0) && recoilForce != 0 && ammo != 0 && Time.time > nextFire && !stop && !checkActive)
        {
            Debug.Log("Shot");
            nextFire = Time.time + fireRate;
            shoot = true;
            ammo--;
            if(needsAmmo)
            {
                ammoCounter.text = "AMMO\n" + ammo.ToString();
            }
        }
        else if (recoilForce != 0 && needsAmmo && ammo == 0 && playerComp.killCount != playerComp.killObjetive && !stop && !checkActive)
        {
            checkActive = true;
            StartCoroutine(OutOfAmmoCheck());
        }
    }

    void FixedUpdate()
    {
        target = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mouseX, mouseY, transform.position.z));
        target.z = crosshair.transform.position.z;

        Vector3 difference = target - bulletGuide.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        bulletGuide.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (shoot)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
   
            GameObject b = Instantiate(bullet, player.transform.position, Quaternion.Euler(0f, 0f, rotationZ)) as GameObject;
            b.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
            player.GetComponent<Rigidbody2D>().AddForce(-direction * recoilForce);
            b.GetComponent<Rigidbody>().AddTorque(1f * bulletRotate, 1f * bulletRotate, 1f * bulletRotate);
            shoot = false;
        }
    }

    IEnumerator OutOfAmmoCheck()
    {
        yield return new WaitForSeconds(1f);
        if (ammo == 0 && playerComp.killCount != playerComp.killObjetive)
        {
            Debug.Log("Out of ammo (check on Coroutine)");
            stop = true;
            playerComp.StartCoroutine(playerComp.LoseAnimation());
        }
        checkActive = false;
    }

    private void LateUpdate()
    {
        target = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mouseX, mouseY, transform.position.z));
        target.z = crosshair.transform.position.z;
        crosshair.transform.position = target;
    }
}
