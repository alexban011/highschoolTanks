using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public GameObject hitEffect;
    public Transform attackPoint;
    public float attackRange = 1;
    public int attackDamage = 50;
    public LayerMask enemy;
    public LayerMask gate;


    void OnCollisionEnter2D(Collision2D collision)
    {
        Attack();
       // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
       // Destroy(effect, 2f);
        Destroy(gameObject);
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemy);
        Collider2D[] hitGate = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, gate);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        foreach (Collider2D gate in hitGate)
        {
            gate.GetComponent<GateScript>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
