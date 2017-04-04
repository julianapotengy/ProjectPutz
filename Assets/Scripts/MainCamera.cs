using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public GameObject[] borders = new GameObject[2];

    public float max;
    public float min;

    void Start ()
    {
        offset = this.transform.position - player.transform.position;
        borders = GameObject.FindGameObjectsWithTag("Border");
        min = borders[0].transform.position.x - 5.5f;
        max = borders[1].transform.position.x + 5.5f;
    }
	
	void Update ()
    {
        //this.transform.position = player.transform.position + offset;
        if (player.transform.position.x < min && player.transform.position.x > max)
        {
            this.transform.position = player.transform.position + offset;
        }
    }
}
