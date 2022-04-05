using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //public GameObject playerOnePrefab;
    //public GameObject playerTwoPrefab;
    /*
    public PlayerInput playerOne;
    public PlayerInput playerTwo;

    public SpawnBlock spawnBlock;
    */
    public GameObject loader;
    public GameObject generator;

    private GameObject[] spawnList;
    public GameObject playerOne;
    public GameObject playerTwo;

    private bool playerOneOnPoint;
    private bool playerTwoOnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //playerOne = generator.GetComponent<LevelGenerator>().playerOnePrefab;
        //playerOne = GameObject.FindWithTag("PlayerOne");
        //playerTwo = GameObject.FindWithTag("PlayerTwo");
        //playerTwo = generator.GetComponent<LevelGenerator>().playerOnePrefab;
        //playerTwo = generator.GetComponent<LevelGenerator>().playerTwoPrefab;

        //playerOnePrefab = transform.Find("PlayerOne(Clone)").gameObject;
        //playerTwoPrefab = transform.Find("PlayerTwo(Clone)").gameObject;
        /*
        playerOne = PlayerInput.Instantiate(playerOnePrefab, controlScheme: "PlayerOne", pairWithDevice: Keyboard.current);
        playerTwo = PlayerInput.Instantiate(playerTwoPrefab, controlScheme: "PlayerTwo", pairWithDevice: Keyboard.current);
        */
    }

    private void Update()
    {
        // Gets all of the spawn out objects and puts them into an aray
        spawnList = GameObject.FindGameObjectsWithTag("SpawnOut");

        playerOne = GameObject.FindWithTag("PlayerOne");
        playerTwo = GameObject.FindWithTag("PlayerTwo");

        // Loops through all the spawn out blocks and checks
        // which player is on the block
        for (int i = 0; i < spawnList.Length; i++)
        {
            if (spawnList[i].GetComponent<SpawnBlock>().playerOneOnPoint)
            {
                playerOneOnPoint = true;
            }
            else if (spawnList[i].GetComponent<SpawnBlock>().playerTwoOnPoint)
            {
                playerTwoOnPoint = true;
            }

            // Loads a new scene if both players are on one of the blocks

            if (playerOneOnPoint && playerTwoOnPoint)
            {
                loader.GetComponent<LevelLoader>().LoadNextLevel();
            }
            // If the end of the list is reached and both players aren't on spawn blocks
            // then the bools are set back to false
            else if(i == spawnList.Length - 1)
            {
                playerOneOnPoint = false;
                playerTwoOnPoint = false;
            }
        }       


        /*if(Mathf.Abs(playerOnePrefab.GetComponent<Player>().position.x) > 300 
            && Mathf.Abs(playerTwoPrefab.GetComponent<Player>().position.x) > 300)
        {
            loader.GetComponent<LevelLoader>().LoadNextLevel();
        }

        if (Mathf.Abs(playerOnePrefab.GetComponent<Player>().position.x) > 300
            && Mathf.Abs(playerTwoPrefab.GetComponent<Player>().position.y) > 400)
        {
            loader.GetComponent<LevelLoader>().LoadNextLevel();
        }

        if (Mathf.Abs(playerOnePrefab.GetComponent<Player>().position.y) > 400
            && Mathf.Abs(playerTwoPrefab.GetComponent<Player>().position.x) > 300)
        {
            loader.GetComponent<LevelLoader>().LoadNextLevel();
        }

        if (Mathf.Abs(playerOnePrefab.GetComponent<Player>().position.y) > 400
            && Mathf.Abs(playerTwoPrefab.GetComponent<Player>().position.y) > 400)
        {
            loader.GetComponent<LevelLoader>().LoadNextLevel();
        }*/
    }
}
