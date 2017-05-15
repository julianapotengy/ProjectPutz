using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidScript : MonoBehaviour
{
    private GameObject point;
    private Player player;
    private bool walk2Player = true;
    private float timer;
    private bool canCount = false;
    private Vector3 initialPos;

    private void Start()
    {
        point = GameObject.Find("Kid2WalkPoint");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        initialPos = new Vector3(this.transform.position.x, this.transform.position.y);
    }

    private void Update()
    {
        if (walk2Player)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, point.transform.position, 0.05f);
        }
        if (canCount)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 4)
        {
            player.canWalk = true;
            this.transform.position = Vector3.MoveTowards(this.transform.position, initialPos, 0.05f);
            canCount = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.Equals(point))
        {
            walk2Player = false;
            canCount = true;
        }
    }
}
