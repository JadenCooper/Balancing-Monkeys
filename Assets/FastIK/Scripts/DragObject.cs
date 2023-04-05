using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Rigidbody2D body;

    public float force;

    private Vector3 mouseOffset;

    private float dragZOffset = 0.1f;

    private bool canDrag = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        // calculate the offset between the mouse position and the body position
        if (canDrag)
        {
            mouseOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragZOffset));
        }

        //body.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void OnMouseDrag()
    {
        // move the body based on the mouse position
        if (canDrag)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragZOffset));
            body.MovePosition(newPosition + mouseOffset);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            canDrag = false;
        }
    }

}
