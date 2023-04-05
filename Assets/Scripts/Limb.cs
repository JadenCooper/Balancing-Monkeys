using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    private Collider2D limbCollider;
    private PlayerControler playerControler;
    private Rigidbody2D rb2d;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        limbCollider = GetComponent<Collider2D>();
        playerControler = GetComponentInParent<PlayerControler>();
        foreach (var collider in playerControler.colliderList)
        {
            Physics2D.IgnoreCollision(limbCollider, collider);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        Debug.Log("Frozen");
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
