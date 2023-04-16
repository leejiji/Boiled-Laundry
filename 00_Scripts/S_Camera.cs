using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Camera : MonoBehaviour
{
    void Start()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;       
    }
}
