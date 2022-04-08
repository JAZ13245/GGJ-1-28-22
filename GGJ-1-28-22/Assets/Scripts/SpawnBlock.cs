using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public bool playerOneOnPoint;
    public bool playerTwoOnPoint;

    public GameObject loader;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -51);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            playerOneOnPoint = true;
        }

        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            playerTwoOnPoint = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            playerOneOnPoint = false;
        }

        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            playerTwoOnPoint = false;
        }

    }
}
