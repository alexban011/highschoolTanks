using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField]
  //  public Text BULLETSnr;
    public GameObject munitieUI;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bullets = 10;
    public int maxBullets = 10;

    public GameObject tancLv1;
    public GameObject tancLv2;
    public GameObject tancLv3;

    public int nrTanc = 0; //pt muzica


    public float bulletForce = 20f;


    void Update()
    {
        if(munitieUI != null)
        {
            munitieUI.transform.localScale = new Vector3((float)bullets / maxBullets, 1, 1);
        }
        
       // BULLETSnr.text = bullets + " Bullets";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bullets > 0)
            {
                bullets--;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        switch (nrTanc)
        {
            case 1:
                tancLv1.GetComponent<PlayerStats>().PlayImpuscare();
                break;
            case 2:
                tancLv2.GetComponent<PlayerStats>().PlayImpuscare();
                break;
            case 3:
                tancLv3.GetComponent<PlayerStats>().PlayImpuscare();
                break;
            default:
                break;
        }

        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
