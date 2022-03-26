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

    private GameObject[] spawnOut;
    public GameObject playerOne;
    public GameObject playerTwo;

    private bool playerOneOnPoint;
    private bool playerTwoOnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        spawnOut = generator.GetComponent<LevelGenerator>().spawnOut;
        playerOne = generator.GetComponent<LevelGenerator>().playerOnePrefab;
        playerTwo = generator.GetComponent<LevelGenerator>().playerTwoPrefab;

        //playerOnePrefab = transform.Find("PlayerOne(Clone)").gameObject;
        //playerTwoPrefab = transform.Find("PlayerTwo(Clone)").gameObject;
        /*
        playerOne = PlayerInput.Instantiate(playerOnePrefab, controlScheme: "PlayerOne", pairWithDevice: Keyboard.current);
        playerTwo = PlayerInput.Instantiate(playerTwoPrefab, controlScheme: "PlayerTwo", pairWithDevice: Keyboard.current);
        */
    }

    private void Update()
    {

        
        for(int i = 0; i < spawnOut.Length; i++)
        {
            if(spawnOut[i] != null)
            {
                //Debug.Log(spawnOut[i].GetComponent<SpawnBlock>().playerTwoOnPoint);
                if (spawnOut[i].GetComponent<SpawnBlock>().playerOneOnPoint)
                {
                    Debug.Log("Player on point");
                    playerOneOnPoint = true;
                }
                else if (spawnOut[i].GetComponent<SpawnBlock>().playerTwoOnPoint)
                {
                    Debug.Log("Player two on point");
                    playerTwoOnPoint = true;
                }
            }
        }

        if(playerOneOnPoint && playerTwoOnPoint)
        {
            Debug.Log("Success");
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
