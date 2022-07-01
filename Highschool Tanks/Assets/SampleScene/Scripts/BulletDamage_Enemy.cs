using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage_Enemy : MonoBehaviour
{
    public GameObject hitEffect;
    public Transform attackPoint;
    public float attackRange = 1;
    //public int stage = 0;
    public int attackDamage = 10;
    public LayerMask good;
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        Attack();
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 2f);
        Destroy(gameObject);
    }

    void Attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, good);

        foreach (Collider2D good in hitPlayer)
        {
            good.GetComponent<PlayerStats>().TakeDamage(attackDamage);
            
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
