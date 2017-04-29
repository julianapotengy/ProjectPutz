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
    private float timer = 0;
    public bool canWalk = true;
    private GameObject walkTutorial;
    private GameObject kid;
    #endregion
    void Start ()
	{
        speed = 90 * Time.deltaTime;
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        walkTutorial = GameObject.Find("WalkTutorial");
        kid = GameObject.Find("Kid");
        kid.GetComponent<KidScript>().enabled = false;
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));
    }
    void Update ()
	{
        if(canWalk)
        {
            axisX = Input.GetAxis("Horizontal");
            //axisY = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(axisX * speed, axisY);
            if (axisX > 0 && !faceRight)
            {
                Flip();
            }
            else if (axisX < 0 && faceRight)
            {
                Flip();
            }
        }
        if (canPickApple && Input.GetKeyUp(KeyCode.Q) && !applePicked)
        {
            StartCoroutine(apple.GetComponent<AppleScript>().FadeApple());
            canWalk = false;
            kid.GetComponent<KidScript>().enabled = true;
            applePicked = true;
        }
        
        timer += Time.deltaTime;
        if (timer >= 7)
            walkTutorial.SetActive(false);
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
