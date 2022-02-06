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
    private bool nearBox = false;
    private bool isCarrying = false;
    private Vector2 pos;

    public Vector2 position { get { return pos; } }
    
    void Update()
    {
        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * speed * Time.deltaTime);

        // Sets the amounts needed for the animation
        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y);
        animator.SetFloat("Magnitude", movementInput.magnitude);

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
        //Debug.Log(pos);

    }

    public void OnMove(InputAction.CallbackContext ctx) 
    {

        movementInput = ctx.ReadValue<Vector2>();
        

    }

    public void OnCarry(InputAction.CallbackContext ctx)
    {
        if (nearBox)
        {
            Debug.Log("Carrying");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        nearBox = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        nearBox = false;
    }

}
