using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region VariableDeclaration
    private float axisX, axisY, speed;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private GameObject apple;
    public float jumpSpeed;
    bool canPickApple = false;
    bool applePicked = false;
    bool faceRight = true;
    #endregion
    void Start ()
	{
        speed = 90 * Time.deltaTime;
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
	}
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));
    }
    void Update ()
	{
        axisX = Input.GetAxis("Horizontal");
        //axisY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(axisX * speed, axisY);
        if (canPickApple && Input.GetKeyUp(KeyCode.Q) && !applePicked)
        {
            StartCoroutine(apple.GetComponent<AppleScript>().FadeApple());
            applePicked = true;
        }
        if(axisX > 0 && !faceRight)
        {
            Flip();
        }
        else if(axisX < 0 && faceRight)
        {
            Flip();
        }
	}

    void Flip()
    {
        faceRight = !faceRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale= scale;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Point1"))
        {
            apple.GetComponent<Rigidbody2D>().gravityScale = 0.4f;
        }

        else if (col.gameObject.name.Equals("Apple"))
        {
            canPickApple = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Apple"))
        {
            canPickApple = false;
        }
    }
}
