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
    private Vector2 pos;
    public bool isCarrying;

   // public MovementState state;

    private enum MovementState {idle, boxIdle, run, boxCarry}

    public Vector2 position { get { return pos; } }
    
    void Update()
    {
        MovementState state;
        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * speed * Time.deltaTime);

        // Sets the amounts needed for the animation
        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y);
        animator.SetFloat("Magnitude", movementInput.magnitude);

        
        if(movementInput.magnitude > 0)
        {
            if (isCarrying)
            {
                state = MovementState.boxCarry;
            }
            else
            {
                state = MovementState.run;
            }

        }
        else
        {
            if (isCarrying)
            {
                state = MovementState.boxIdle;
            }
            else
            {
                state = MovementState.idle;
            }

        }

        

        // Flips the sprite depending on if
        // the character is going left or right
        if (movementInput.x > 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        else if (movementInput.x < 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

        pos = transform.position;

        animator.SetInteger("State", (int)state);

    }

    public void OnMove(InputAction.CallbackContext ctx) 
    {
        movementInput = ctx.ReadValue<Vector2>();
    }

}
