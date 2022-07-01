using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.

public class Move_Aim : MonoBehaviour
{
    public float moveSpeed = 5f;

    private KeyCode a;

    public Rigidbody2D rb_turela;
    public Rigidbody2D rb_corp;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown('a'))
        {
            rb_corp.transform.eulerAngles = new Vector3(0, 0, -50);
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb_corp.MovePosition(rb_corp.position + movement * moveSpeed * Time.fixedDeltaTime);
        //rb_turela.MovePosition(rb_turela.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb_turela.position = rb_corp.position;
        Vector2 lookDir = mousePos - rb_turela.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
        rb_turela.rotation = angle;
        
    }
}
