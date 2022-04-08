using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject loader;
    public GameObject generator;

    private GameObject[] spawnList;
    public GameObject playerOne;
    public GameObject playerTwo;

    private bool playerOneOnPoint;
    private bool playerTwoOnPoint;

    private Gamepad controller1;
    private Gamepad controller2;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
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

    }

}
