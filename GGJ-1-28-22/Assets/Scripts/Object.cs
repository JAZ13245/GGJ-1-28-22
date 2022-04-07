using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ItemState {
    OnGround, HeldByPlayerOne, HeldByPlayerTwo
}


public class Object : MonoBehaviour
{
    // ids
    // 0 - static
    // 1 - box
    // 2 - pressure plate
    // 3 - lever
    // 4 - door

    public int itemID;
    public ItemState currentState;

    public bool touchingPlayerOne, touchingPlayerTwo, touchingBox, open, powered;

    public GameObject powerSource;

    private bool previousHitPlayerOne = true;
    private bool previousHitPlayerTwo = true;

    public GameManager gameManager;
    public BoxCollider2D grabCollider;

    void Start() {
        
    }
    void Update() {
        
        switch (itemID)
        {
            case 0: break;
            case 1: BoxUpdate(); break;
            case 2: PressurePlateUpdate(); break;
            case 3: LeverUpdate(); break;
            case 4: DoorUpdate(); break;
        }

    }

    void OnTriggerStay2D(Collider2D c)
    {
        // if colliding with either player, true
        if (c.gameObject.name.Contains("PlayerOne")) { touchingPlayerOne = true;  }
        if (c.gameObject.name.Contains("PlayerTwo")) { touchingPlayerTwo = true;  }
        if (c.gameObject.name.Contains("Box")) { touchingBox = true; }
    }

    void OnTriggerExit2D(Collider2D c) {
        // if leaving collision with either player, false
        if (c.gameObject.name.Contains("PlayerOne")) { touchingPlayerOne = false; }
        if (c.gameObject.name.Contains("PlayerTwo")) { touchingPlayerTwo = false; }
        if (c.gameObject.name.Contains("Box")) { touchingBox = false; }

    }
    

    void BoxUpdate() {
        if (gameManager.playerOne != null && GetComponent<TimeState>().currentTimeState == TimePeriod.Future) // player one is future
        {
            if (gameManager.playerOne.GetComponent<Player>().carryButtonHit != previousHitPlayerOne)
            {
                if (currentState == ItemState.HeldByPlayerOne)
                {
                    currentState = ItemState.OnGround;
                    Vector3 playerOnePos = gameManager.playerOne.gameObject.transform.position;
                    GetComponent<Transform>().position = new Vector3(playerOnePos.x, playerOnePos.y - 0.55f, playerOnePos.z);
                    gameManager.playerOne.GetComponent<Player>().isCarrying = false;
                    Show();
                }
                else if (touchingPlayerOne) { currentState = ItemState.HeldByPlayerOne; }

                previousHitPlayerOne = gameManager.playerOne.GetComponent<Player>().carryButtonHit;
            }
        }
        if (gameManager.playerOne != null && GetComponent<TimeState>().currentTimeState == TimePeriod.Past) // player two is past
        {
            if (gameManager.playerTwo.GetComponent<Player>().carryButtonHit != previousHitPlayerTwo)
            {
                if (currentState == ItemState.HeldByPlayerTwo)
                {
                    currentState = ItemState.OnGround;
                    Vector3 playerTwoPos = gameManager.playerTwo.gameObject.transform.position;
                    GetComponent<Transform>().position = new Vector3(playerTwoPos.x, playerTwoPos.y - 0.55f, playerTwoPos.z);
                    gameManager.playerTwo.GetComponent<Player>().isCarrying = false;
                    Show();
                }
                else if (touchingPlayerTwo) { currentState = ItemState.HeldByPlayerTwo; }

                previousHitPlayerTwo = gameManager.playerTwo.GetComponent<Player>().carryButtonHit;
            }
        }
        
        if(currentState == ItemState.HeldByPlayerOne)
        {
            gameManager.playerOne.GetComponent<Player>().isCarrying = true;
            Hide();
        }
        else if(currentState == ItemState.HeldByPlayerTwo)
        {
            gameManager.playerTwo.GetComponent<Player>().isCarrying = true;
            Hide();
        }
    }

    void PressurePlateUpdate()
    {
        if (touchingBox || touchingPlayerOne || touchingPlayerTwo)
        {
            powered = true;
        }
        else
        {
            powered = false;
        }
    }

    void LeverUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && GetComponent<TimeState>().currentTimeState == TimePeriod.Future) // player one is future
        {
            if (touchingPlayerOne)
            {
                if (!powered) { powered = true; }
                else { powered = false; }
                transform.Rotate(new Vector3(0, 0, 180));
            }
        }
        if (Input.GetKeyDown(KeyCode.RightControl) && GetComponent<TimeState>().currentTimeState == TimePeriod.Past) // player two is past
        {
            if (touchingPlayerTwo)
            {
                if (!powered) { powered = true; }
                else { powered = false; }
                transform.Rotate(new Vector3(0, 0, 180));
            }
        }
    }

    void DoorUpdate()
    {
        if (powerSource != null)
        {
            if (powerSource.GetComponent<Object>().powered)
            {
                open = true;
                Hide();
            }
            else
            {
                open = false;
                Show();
            }
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
