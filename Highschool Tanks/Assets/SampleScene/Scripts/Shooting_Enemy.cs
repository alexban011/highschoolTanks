using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Enemy : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;


    public float bulletForce = 20f;


    void Update()
    {
       // munitieUI.transform.localScale = new Vector3((float)bullets / 10, 1, 1);
        // BULLETSnr.text = bullets + " Bullets";
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
                Shoot();

        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
