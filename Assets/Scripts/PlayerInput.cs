using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private InputActionReference freeze;

    public PlayerControler currentPlayer;

    private void OnEnable()
    {
        freeze.action.performed += PreformFreeze;
    }

    private void OnDisable()
    {
        freeze.action.performed -= PreformFreeze;
    }

    private void PreformFreeze(InputAction.CallbackContext obj)
    {
        currentPlayer.Freeze();
    }
}
