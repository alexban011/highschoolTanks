using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Aim : MonoBehaviour
{
    public float moveSpeed = 5f;

   // int rotatiaTancului = 0;
   // int rotatiaTanculuiAbsoluta = 0;
    public GameObject corp_tank;

    public Rigidbody2D rb_turela;
    public Rigidbody2D rb_corp;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    float x;
    float y;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        /*if (Input.GetKey(KeyCode.A))
        {
            rotatiaTancului -= 1;
            corp_tank.transform.eulerAngles = new Vector3(0, 0, rotatiaTancului);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotatiaTancului += 1;
            corp_tank.transform.eulerAngles = new Vector3(0, 0, rotatiaTancului);
        }*/
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        /*
        Vector2 VectorFromAngle(float theta)
        {
            return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
        } 

        if (rotatiaTancului > 0)
        {
            rotatiaTanculuiAbsoluta = rotatiaTancului;
        }else if (rotatiaTancului < 0)
        {
            rotatiaTanculuiAbsoluta = 360 - rotatiaTancului;
        }
        */
        rb_corp.MovePosition(rb_corp.position + movement * moveSpeed * Time.fixedDeltaTime);
       
        
        //rb_turela.MovePosition(rb_turela.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb_turela.position = rb_corp.position;
        Vector2 lookDir = mousePos - rb_turela.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
        rb_turela.rotation = angle;
        
    }
}
