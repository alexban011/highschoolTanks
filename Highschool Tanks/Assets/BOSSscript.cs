using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSscript : MonoBehaviour
{
    public float viteza = 2f;
    public float distanta = 5f;
    public float distantaAproape = 10f;
    public float distantaNecesaraAgravare = 10f;
    public float damage = 80;
    public float distantaHit = 10f;
    public float pauzaLovituri = 200f;
    public Rigidbody2D enemy;
    public Rigidbody2D Player;
    //public int ok = 0;

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    Vector2 targetPos;
    Vector3 targetPosition;

    private float timp;
    private Transform target;


    void Start()
    {
        //   target = GameObject.FindGameObjectWithTag("SmallTankB-BUN").GetComponent<Transform>();
        target = Player.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector2 lookDir = targetPos - enemy.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        enemy.rotation = angle;
        timp = timp + 0.02f;
    }

    void Update()
    {
        int T = 0;
        if ((Vector2.Distance(transform.position, target.position) > distanta && Vector2.Distance(transform.position, target.position) < distantaNecesaraAgravare) || Vector2.Distance(transform.position, target.position) < distantaAproape)
        {
            // transform.position = Vector2.MoveTowards(transform.position, target.position, viteza * Time.deltaTime);
            targetPosition = new Vector3(Player.position.x, Player.position.y);
            targetPos = targetPosition;
            T = 1;

        }
        if (timp >= pauzaLovituri)
        {
            if (Vector2.Distance(transform.position, target.position) < distantaHit && T == 1)
            {
                HitPlayer(damage);
                timp = 0f;
                T = 0;
            }
            timp = 0f;
            T = 0;
        }
    }
    void HitPlayer(float damageGiven)
    {
        GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        
            GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);

        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
            rb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
        // GameObject.FindGameObjectWithTag("SmallTankB-BUN").GetComponent<PlayerStats>().viata = GameObject.FindGameObjectWithTag("SmallTankB-BUN").GetComponent<PlayerStats>().viata - damageGiven;

        Player.GetComponent<PlayerStats>().viata = Player.GetComponent<PlayerStats>().viata - damageGiven;

    }
}
