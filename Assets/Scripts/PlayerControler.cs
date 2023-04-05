using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Collider2D[] colliderList = new Collider2D[10];
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        colliderList = GetComponentsInChildren<Collider2D>();
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
