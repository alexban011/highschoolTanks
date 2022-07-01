using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_stats : MonoBehaviour
{
    public GameObject tank;
    public Rigidbody2D rb;
    private int viata = 100;
    private int ViataPrezenta = 0;
    public int damage;
    public int armor;
    public float moveSpeed = 5f;

    public Transform attackPoint_W;
    public Transform attackPoint_S;
    public Transform attackPoint_D;
    public Transform attackPoint_A;

    public Transform attackPoint_W_D;
    public Transform attackPoint_S_D;
    public Transform attackPoint_W_A;
    public Transform attackPoint_S_A;

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;

    Vector2 movement;
    public Animator Animator;
    
    void Start()
    {
        viata = viata + armor / 100 * viata;
        ViataPrezenta = viata;
    }

    
    void Update()
    {
        //attack

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        //movment

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            Animator.SetBool("Oblic", true);
        }else
            Animator.SetBool("Oblic", false);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Animator.SetFloat("Horizontal", movement.x);
        Animator.SetFloat("Vertical", movement.y);
        Animator.SetFloat("Speed", movement.sqrMagnitude);



        //Stats

        if (viata <= 0)
        {
            Destroy(this.gameObject); // sterge Playerul cand nu mai are viata;
            //Die();
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Attack()
    {
        //Animation
    
        Animator.SetTrigger("Attack");
    
    
        //Detect enemies in range of attack
        Collider2D[] hitEnemiesW = Physics2D.OverlapAreaAll(attackPoint.position, attackPoint_W.position, enemyLayer);
        Collider2D[] hitEnemiesS = Physics2D.OverlapAreaAll(attackPoint.position, attackPoint_S.position, enemyLayer);
        Collider2D[] hitEnemiesA = Physics2D.OverlapAreaAll(attackPoint.position, attackPoint_A.position, enemyLayer);
        Collider2D[] hitEnemiesD = Physics2D.OverlapAreaAll(attackPoint.position, attackPoint_D.position, enemyLayer);

        Collider2D[] hitEnemiesW_D = Physics2D.OverlapAreaAll(attackPoint.position, attackPoint_W_D.position, enemyLayer);
        Collider2D[] hitEnemiesS_D = Physics2D.OverlapAreaAll(attackPoint.position, attackPoint_S_D.position, enemyLayer);
        Collider2D[] hitEnemiesW_A = Physics2D.OverlapAreaAll(attackPoint.position, attackPoint_W_A.position, enemyLayer);
        Collider2D[] hitEnemiesS_A = Physics2D.OverlapAreaAll(attackPoint.position, attackPoint_S_A.position, enemyLayer);

        //Damage them
        if (Input.GetAxisRaw("Vertical") > 0)
        foreach (Collider2D enemy in hitEnemiesW)
        {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
        }

            if (Input.GetAxisRaw("Vertical") < 0)
        foreach (Collider2D enemy in hitEnemiesS)
        {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
        }

            if (Input.GetAxisRaw("Horizontal") < 0)
        foreach (Collider2D enemy in hitEnemiesA)
        {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
        }

            if (Input.GetAxisRaw("Horizontal") > 0)
        foreach (Collider2D enemy in hitEnemiesD)
        {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
        }

        if (Animator.GetBool("Oblic")==true && Input.GetAxisRaw("Vertical") > 0 && Input.GetAxisRaw("Horizontal") > 0) {
            foreach (Collider2D enemy in hitEnemiesW_D)
            {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
        }

        if (Animator.GetBool("Oblic") == true && Input.GetAxisRaw("Vertical") > 0 && Input.GetAxisRaw("Horizontal") < 0)
        {
            foreach (Collider2D enemy in hitEnemiesW_A)
            {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
        }

        if (Animator.GetBool("Oblic") == true && Input.GetAxisRaw("Vertical") < 0 && Input.GetAxisRaw("Horizontal") < 0)
        {
            foreach (Collider2D enemy in hitEnemiesS_A)
            {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
        }

        if (Animator.GetBool("Oblic") == true && Input.GetAxisRaw("Vertical") < 0 && Input.GetAxisRaw("Horizontal") > 0)
        {
            foreach (Collider2D enemy in hitEnemiesS_D)
            {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }

    void Die()
    {
       // Animator.SetBool("Dead", true);

        this.enabled = false;

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint_W == null || attackPoint_S == null || attackPoint_A == null || attackPoint_D == null || attackPoint_W_D == null || attackPoint_S_D == null || attackPoint_W_A == null || attackPoint_S_A == null )
            return;

        Gizmos.DrawLine(attackPoint.position, attackPoint_W.position);
        Gizmos.DrawLine(attackPoint.position, attackPoint_S.position);
        Gizmos.DrawLine(attackPoint.position, attackPoint_A.position);
        Gizmos.DrawLine(attackPoint.position, attackPoint_D.position);
        Gizmos.DrawLine(attackPoint.position, attackPoint_W_D.position);
        Gizmos.DrawLine(attackPoint.position, attackPoint_S_D.position);
        Gizmos.DrawLine(attackPoint.position, attackPoint_W_A.position);
        Gizmos.DrawLine(attackPoint.position, attackPoint_S_A.position);

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

