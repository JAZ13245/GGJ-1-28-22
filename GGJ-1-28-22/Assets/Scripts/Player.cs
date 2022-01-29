using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float speed = 1.5f;
    private Vector2 movementInput;
    public GameObject playerPrefab;

    void Start()
    {
        //var player1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "PlayerOne", pairWithDevice: Keyboard.current);
        //var player2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "PlayerTwo", pairWithDevice: Keyboard.current);
    }

    void Update()
    {

        // Old

        //float yInput = Input.GetAxis("Horizontal");
        //transform.Translate(yInput * speed * Time.deltaTime, 0f, 0f);

        //float xInput = Input.GetAxis("Vertical");
        //transform.Translate(0f, xInput* speed * Time.deltaTime, 0f);

        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * speed * Time.deltaTime);

    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
