using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject TotalLife;
    public GameObject SliderViata;
   // public GameObject drop;
    public GameObject tank;
    // public SpriteRenderer tank_sprite;
    public GameObject cheita;
    public GameObject tancLv1;
    public GameObject tancLv2;
    public GameObject tancLv3;
    public int maxHealth = 100;
    public int currentHealth;

    void Update()
    {

        //Slidere
        //transform.Find("Bar").localScale = new Vector3();
       SliderViata.transform.localScale = new Vector3((float)currentHealth / maxHealth, 1, 1);

    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        cheita.SetActive(true);
        // drop.SetActive(true);
        //this.enabled = false;
        tank.SetActive(false);
        //tank_sprite.color.maxColorComponent;
        
        Destroy(TotalLife);
        
        tancLv1.GetComponent<PlayerStats>().PlayExplozie();
        tancLv2.GetComponent<PlayerStats>().PlayExplozie();
        tancLv3.GetComponent<PlayerStats>().PlayExplozie();
        Destroy(tank);
        // this.gameObject.SetActive(false);
    }
}
