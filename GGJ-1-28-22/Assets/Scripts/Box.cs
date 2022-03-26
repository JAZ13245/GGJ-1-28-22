using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool carrying;
    public GameManager gameManager;
    public BoxCollider2D grabCollider;
    private BoxCollider2D playerOneCollider;
    private BoxCollider2D playerTwoCollider;

    void Start() {
        carrying = false;
        //playerOneCollider = gameManager.playerOne.GetComponent<BoxCollider2D>();
        //playerTwoCollider = gameManager.playerTwo.GetComponent<BoxCollider2D>();
    }
    void Update() {
        //OnTriggerStay2D(gameManager.playerOne.GetComponent<BoxCollider2D>());
        //OnTriggerStay2D(gameManager.playerTwo.GetComponent<BoxCollider2D>());
        /*
        if (grabCollider.bounds.Intersects(gameManager.playerOne.GetComponent<BoxCollider2D>().bounds))
        {
            Debug.Log("box collision uwu");
        }
        else if (grabCollider.bounds.Intersects(gameManager.playerTwo.GetComponent<BoxCollider2D>().bounds))
        {
            Debug.Log("box collision uwu");
        }
        */
    }

    void OnTriggerStay2D(Collider2D c)
    {
       
        Debug.Log("i am the among" + c.gameObject.name);
    }
}
