using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public bool playerOneOnPoint;
    public bool playerTwoOnPoint;

    public GameObject loader;

    // Start is called before the first frame update
    void Start()
    {
        //yes
        //playerTwoOnPoint = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(playerTwoOnPoint);
        if(playerOneOnPoint || playerTwoOnPoint)
        {
            //loader.GetComponent<LevelLoader>().LoadNextLevel();
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            //Debug.Log("Player on point");
            //playerOneOnPoint = true;
        }

        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            //Debug.Log("Player two on point");
            //playerTwoOnPoint = true;
        }

        //Debug.Log("Collider");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            playerTwoOnPoint = true;
        }
        else
        {
            playerTwoOnPoint = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {

        //Debug.Log("Test");
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
            //playerTwoOnPoint = false;
        }
        //Debug.Log("Test");
    }
}
