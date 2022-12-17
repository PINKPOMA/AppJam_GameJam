using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    float angle;
    private Vector2 target;
    Vector2 mouse;
    private void Start()
    {
        target = transform.position;
    }

    private void Update()
    {
        target = new Vector3 (-Input.GetAxis("Mouse Y"),0);
    }

}
