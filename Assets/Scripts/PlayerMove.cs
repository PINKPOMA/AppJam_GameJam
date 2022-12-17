using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed = 4f;
    private Vector2 moveDir;

    private void Update()
    {
        InputUpdate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void InputUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveDir.Set(h, v);
    }

    private void Move()
    {
        transform.Translate(MoveSpeed * Time.fixedDeltaTime * moveDir.normalized);
    }
}
