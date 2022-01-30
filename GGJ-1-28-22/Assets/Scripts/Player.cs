using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float speed = 1.5f;
    private Vector2 movementInput;
    public GameObject playerPrefab;
    public Animator animator;

    void Update()
    {

        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * speed * Time.deltaTime);

        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y);
        animator.SetFloat("Magnitude", movementInput.magnitude);

    }

    public void OnMove(InputAction.CallbackContext ctx) 
    {

        movementInput = ctx.ReadValue<Vector2>();

    }
}
