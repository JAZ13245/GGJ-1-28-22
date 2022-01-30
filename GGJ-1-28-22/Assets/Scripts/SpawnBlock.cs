using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    bool playerOneOnPoint = false;
    bool playerTwoOnPoint = false;

    // Start is called before the first frame update
    void Start()
    {
        //yes
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            //Debug.Log("Player on point");
            playerOneOnPoint = true;
        }

        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            //Debug.Log("Player two on point");
            playerTwoOnPoint = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            //Debug.Log("Player off point");
            playerOneOnPoint = false;
        }

        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            //Debug.Log("Player two off point");
            playerTwoOnPoint = false;
        }

    }
}
