using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void Freeze()
    {
        if (rb2d.gravityScale == 0f)
        {
            rb2d.gravityScale = 1f;
        }
        else
        {
            rb2d.gravityScale = 0f;
            rb2d.velocity = Vector3.zero;
        }
    }
}
