using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    SpriteRenderer sprite;
    GameObject Qkeyboard;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        Qkeyboard = GameObject.Find("QTutorial");
    }

    private void Start()
    {
        Qkeyboard.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name.Equals("Limit1"))
        {
            Qkeyboard.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(Qkeyboard);
            Destroy(this.gameObject);
        }
    }
    /*public IEnumerator FadeApple()
    {
        Color auxColor = sprite.color;
        for (float i = 1; i >= 0; i-=0.1f)
        {
            auxColor.a = i;
            sprite.color= auxColor;
            yield return new WaitForSeconds(0.03f);
        }
        Destroy(this.gameObject);
    }*/
}
