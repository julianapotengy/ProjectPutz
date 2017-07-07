using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManVision : MonoBehaviour
{
    private Text txt;
    private bool canTalk, won;
    private float timer;

	void Start ()
    {
        txt = GameObject.Find("TextBox").GetComponent<Text>();
        canTalk = false;
        won = false;
	}
	
	void Update ()
    {
        if (canTalk && this.gameObject.name.Equals("Vision"))
        {
            txt.text = "Find the man that took your mother";
            timer += Time.deltaTime;
        }
        else if (canTalk && this.gameObject.name.Equals("BadVision"))
        {
            txt.text = "You found me";
            timer += Time.deltaTime;
            won = true;
        }
        if(timer >= 5 && !won)
        {
            txt.text = "";
            canTalk = false;
            timer = 0;
        }
        else if(timer >= 4 && won)
        {
            Application.LoadLevel(2);
        }
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Player") && !canTalk && this.gameObject.name.Equals("Vision"))
        {
            txt.text = "Press E";
            if (Input.GetKey(KeyCode.E))
                canTalk = true;
        }
        if (col.gameObject.tag.Equals("Player") && !canTalk && this.gameObject.name.Equals("BadVision"))
        {
            txt.text = "Press E";
            if (Input.GetKey(KeyCode.E))
                canTalk = true;
        }
    }
}
