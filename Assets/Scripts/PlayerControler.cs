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
        //rb2d.simulated = !rb2d.simulated;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            Debug.Log("Hit Pickup");
            collision.gameObject.tag = gameObject.tag;
            collision.GetComponent<Pickup>().PreformPickUp();
        }
    }
}
