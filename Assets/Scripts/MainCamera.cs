using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public GameObject[] borders = new GameObject[2];

    public float max;
    public float min;

    private GameObject fadein;
    private bool startFadein;

    void Start ()
    {
        offset = this.transform.position - player.transform.position;
        borders = GameObject.FindGameObjectsWithTag("Border");
        min = borders[0].transform.position.x - 13f;
        max = borders[1].transform.position.x + 5.5f;

        startFadein = true;
        fadein = GameObject.Find("FadeIn");
        fadein.GetComponent<Image>().color = new Color(0, 0, 0, 1);
    }
	
	void Update ()
    {
        if (player.transform.position.x < min && player.transform.position.x > max)
        {
            this.transform.position = player.transform.position + offset;
        }
        if (startFadein)
        {
            fadein.GetComponent<Image>().color -= new Color(0, 0, 0, 0.5f * Time.deltaTime);
            if (fadein.GetComponent<Image>().color.a <= 0)
                startFadein = false;
        }
    }
}
