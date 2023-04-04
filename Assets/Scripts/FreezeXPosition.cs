using UnityEngine;

public class FreezeXPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    
    private void Start()
    {
        initialPosition = transform.position;
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            var position = transform.position;
            position.x = initialPosition.x;
            transform.position = position;
        }
    }
}
