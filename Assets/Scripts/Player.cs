using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private float axisX, axisY, speed;
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private GameObject apple;

	void Start ()
	{
        speed = 90 * Time.deltaTime;
        body = this.GetComponent<Rigidbody2D>();
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
        body.velocity = new Vector2(axisX * speed, axisY);
	}

    private void OnTriggerEnter2D(Collider2D p)
    {
        if(p.gameObject.name.Equals("Point1"))
        {
            apple.GetComponent<Rigidbody2D>().gravityScale = 0.4f;
        }
    }
}
