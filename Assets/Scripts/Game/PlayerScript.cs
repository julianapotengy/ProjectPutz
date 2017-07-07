using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    #region VariableDeclaration
    float axisX, axisY, speed;
    public float jumpForce;
    Rigidbody2D rb;
    Animator anim;
    bool running;
    bool faceRight = true;
    public bool grounded = false;
    public bool canMove = true;
    #endregion
    void Start ()
    {
        speed = 70 * Time.deltaTime;
        //jumpForce = 6000;
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));
        anim.SetBool("canJump", grounded);
        anim.SetBool("running", running);

        if (canMove)
        {
            if (running)
            {
                rb.velocity = new Vector2(axisX * speed * 1.5f, axisY);
            }
            else rb.velocity = new Vector2(axisX * speed, axisY);

            if (grounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
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
            if (Input.GetKey(KeyCode.LeftShift))
            {
                running = true;
            }
            else running = false;
            if (axisX > 0 && !faceRight)
            {
                Flip();
            }
            else if (axisX < 0 && faceRight)
            {
                Flip();
            }
        }
    }
    void Flip()
    {
        faceRight = !faceRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
