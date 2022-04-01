using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemState {
    OnGround, HeldByPlayerOne, HeldByPlayerTwo
}
public enum TimeState { Past,Future }

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

    public TimeState originalTimeState;
    public TimeState currentTimeState;
    public GameObject pastVersion;
    public GameObject futureVersion;
    public Vector3 prevLoc;


    public GameManager gameManager;
    public BoxCollider2D grabCollider;

    void Start() {
        prevLoc = transform.position;
        currentTimeState = originalTimeState;
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
        TimeUpdate();
        prevLoc = transform.position;
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

    // current time rules implemented:
    // past effects future
    // future doesn't effect past
    void TimeUpdate()
    {
        if(futureVersion != null || pastVersion != null)
        {
            if (originalTimeState == TimeState.Past)
            {
                // if the past versin has moved
                if (transform.position != prevLoc)
                {
                    Debug.Log("changed");
                    // update the future version to match the new past version position
                    futureVersion.GetComponent<Object>().PastUpdated();
                }
            }
            else if (originalTimeState == TimeState.Future)
            {

            }
        }
    }

    void PastUpdated()
    {
        if (originalTimeState == TimeState.Past)
        {

        }
        else if (originalTimeState == TimeState.Future) 
        {
            // if the past version is moved, update the future version to have the new position
            transform.position = pastVersion.transform.position;
        }
    }

    void BoxUpdate() {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTimeState == TimeState.Future) // player two is future
            {
                if (touchingPlayerTwo) { }
            }
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
 
        if (Input.GetKeyDown(KeyCode.E) && (touchingPlayerOne || touchingPlayerTwo))
        {
            if (!powered) { powered = true; }
            else { powered = false; }
            transform.Rotate(new Vector3(0,0,180));
        }
    }

    void DoorUpdate()
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
