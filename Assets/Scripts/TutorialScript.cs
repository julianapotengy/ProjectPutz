using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    SpriteRenderer sprite;
    Color auxColor;
    float timer;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        auxColor = sprite.color;
    }

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5)
        {
            StartCoroutine(FadeTutorial());
            timer = 0;
        }
        if(auxColor.a <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public IEnumerator FadeTutorial()
    {
        for (float i = 1; i >= 0; i -= 0.05f)
        {
            auxColor.a = i;
            sprite.color = auxColor;
            yield return new WaitForSeconds(0.03f);
        }
        Destroy(this.gameObject);
    }
}
