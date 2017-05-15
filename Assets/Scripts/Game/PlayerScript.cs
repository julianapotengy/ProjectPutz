using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float axisX, axisY, speed, jumpForce;
    Rigidbody2D rb;
    Animator anim;
    bool faceRight = true;
    bool running;
    public bool canJump = false;
    public bool canMove = true;

    void Start ()
    {
        speed = 90 * Time.deltaTime;
        jumpForce = 3000;
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));
        anim.SetBool("canJump", canJump);
        anim.SetBool("running", running);

        if(canMove)
        {
            if (running)
            {
                rb.velocity = new Vector2(axisX * speed * 1.5f, axisY);
            }
            else rb.velocity = new Vector2(axisX * speed, axisY);

            if (canJump && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
            {
                rb.AddForce(Vector2.up * jumpForce);
            }
        }
    }

    void Update ()
    {
        if (canMove)
        {
            axisX = Input.GetAxis("Horizontal");
            //axisY = Input.GetAxis("Vertical");
            if (axisX > 0 && !faceRight)
            {
                Flip();
            }
            else if (axisX < 0 && faceRight)
            {
                Flip();
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                running = true;
            }
            else running = false;
        }
    }
    void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Platform"))
        {
            canJump = true;
        }
        else canJump = false;
    }
}
