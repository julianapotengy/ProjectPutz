using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public IEnumerator FadeApple()
    {
        Color auxColor = sprite.color;
        for (float i = 1; i >= 0; i-=0.1f)
        {
            auxColor.a = i;
            sprite.color= auxColor;
            yield return new WaitForSeconds(0.03f);
        }
        Destroy(this.gameObject);
    }
}
