using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeavyShooting : MonoBehaviour
{
    [SerializeField]
    //  public Text BULLETSnr;
    public GameObject munitieUI;

    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject bulletPrefab;
    public int bullets = 60;
    public int maxBulletsPerTanc = 60;

    public GameObject tancLv1;
    public GameObject tancLv2;
    public GameObject tancLv3;

    public float bulletForce = 20f;


    void Update()
    {
        munitieUI.transform.localScale = new Vector3((float)bullets / maxBulletsPerTanc, 1, 1);
        // BULLETSnr.text = bullets + " Bullets";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bullets > 0)
            {
                bullets -= 2;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        if (tancLv1 != null)
        {
            tancLv1.GetComponent<PlayerStats>().PlayImpuscare();
        }
        if (tancLv2 != null)
        {
            tancLv2.GetComponent<PlayerStats>().PlayImpuscare();
        }
        if (tancLv3 != null)
        {
            tancLv3.GetComponent<PlayerStats>().PlayImpuscare();
        }
        
        GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
    }
}
