using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float speed = 1.5f;
    private Vector2 movementInput;
    public GameObject playerPrefab;
    private InputControl lastKeyPressed;
    private InputAction.CallbackContext lastCtx;
    private Vector2 lastMovementInput;

    void Update()
    {

        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * speed * Time.deltaTime);

    }

    public void OnMove(InputAction.CallbackContext ctx) 
    {

        movementInput = ctx.ReadValue<Vector2>();

    }
}
