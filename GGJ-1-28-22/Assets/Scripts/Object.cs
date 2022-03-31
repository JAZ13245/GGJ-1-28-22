using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemState {
    OnGround, HeldByPlayerOne, HeldByPlayerTwo
}
public class Object : MonoBehaviour
{
    // ids
    // 0 - static
    // 1 - box

    public int itemID;
    public ItemState currentState;

    public bool touchingPlayerOne, touchingPlayerTwo;
    

    public GameManager gameManager;
    public BoxCollider2D grabCollider;

    void Start() {
    }
    void Update() {
        switch (itemID)
        {
            case 0: break;
            case 1: BoxUpdate(); break;
            case 2: break;
        }

    }

    void OnTriggerStay2D(Collider2D c)
    {
        // if colliding with either player, true
        if (c.gameObject.name.Contains("PlayerOne")) { touchingPlayerOne = true;  }
        if (c.gameObject.name.Contains("PlayerTwo")) { touchingPlayerTwo = true;  }

    }

    void OnTriggerExit2D(Collider2D c) {
        // if leaving collision with either player, false
        if (c.gameObject.name.Contains("PlayerOne")) { touchingPlayerOne = false; }
        if (c.gameObject.name.Contains("PlayerTwo")) { touchingPlayerTwo = false; }
    }

    void BoxUpdate() {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("e");
            if (touchingPlayerOne) { currentState = ItemState.HeldByPlayerOne; }
            else if (touchingPlayerTwo) { currentState = ItemState.HeldByPlayerTwo; }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if (currentState == ItemState.HeldByPlayerOne) 
            {
                currentState = ItemState.OnGround;
                Vector3 playerOnePos = gameManager.playerOne.gameObject.transform.position;
                GetComponent<Transform>().position = new Vector3(playerOnePos.x, playerOnePos.y - 0.55f, playerOnePos.z);
                Show();
            }
            if (currentState == ItemState.HeldByPlayerTwo)
            {
                currentState = ItemState.OnGround;
                Vector3 playerTwoPos = gameManager.playerTwo.gameObject.transform.position;
                GetComponent<Transform>().position = new Vector3(playerTwoPos.x, playerTwoPos.y-0.55f, playerTwoPos.z);
                Show();
            }
        }
        
        if(currentState == ItemState.HeldByPlayerOne || currentState == ItemState.HeldByPlayerTwo)
        {
            Hide();
        }
    }

    void Hide()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D c in colliders)
        {
            c.enabled = false;
        }
    }
    void Show()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D c in colliders)
        {
            c.enabled = true;
        }
    }
}
