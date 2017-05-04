using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidScript : MonoBehaviour
{
    private GameObject player;
    private bool walk2Player = true;
    private float timer;
    private bool canCount = false;
    private Vector3 initialPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPos = new Vector3(this.transform.position.x, this.transform.position.y);
    }

    private void Update()
    {
        if (walk2Player)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 0.05f);
        }
        if (canCount)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 4)
        {
            player.GetComponent<Player>().canWalk = true;
            this.transform.position = Vector3.MoveTowards(this.transform.position, initialPos, 0.05f);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.Equals(player))
        {
            walk2Player = false;
            canCount = true;
        }
    }
}
