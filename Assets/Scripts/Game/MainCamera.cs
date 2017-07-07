using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    private float offset;
    public GameObject[] borders = new GameObject[2];

    public float max;
    public float min;

    private GameObject fadein;
    private bool startFadein;

    void Start ()
    {
        offset = this.transform.position.x - player.transform.position.x;
        borders = GameObject.FindGameObjectsWithTag("Border");
        min = borders[0].transform.position.x - 14.5f;
        max = borders[1].transform.position.x + 3.8f;

        startFadein = true;
        fadein = GameObject.Find("FadeIn");
        fadein.GetComponent<Image>().color = new Color(0, 0, 0, 1);
    }
	
	void Update ()
    {
        if (player.transform.position.x < min && player.transform.position.x > max)
        {
            this.transform.position = new Vector3(player.transform.position.x + offset, this.transform.position.y, this.transform.position.z);
        }
        if (startFadein)
        {
            fadein.GetComponent<Image>().color -= new Color(0, 0, 0, 0.4f * Time.deltaTime);
            if (fadein.GetComponent<Image>().color.a <= 0)
                startFadein = false;
        }
    }
}
