using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_script : MonoBehaviour
{
   // public float moveSpeed = 5f;

    public Rigidbody2D rb_turela;
    public Rigidbody2D rb_corp;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");
        rb_turela.position = rb_corp.position;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        // rb_corp.MovePosition(rb_corp.position + movement * moveSpeed * Time.fixedDeltaTime);
        // rb_turela.MovePosition(rb_turela.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb_turela.position = rb_corp.position;
        Vector2 lookDir = mousePos - rb_turela.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb_turela.rotation = angle;
    }
}
