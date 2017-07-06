using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void ChangeScene(int n)
    {
        Application.LoadLevel(n);
    }
}
