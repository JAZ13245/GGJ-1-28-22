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

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        //playerOnePrefab = transform.Find("PlayerOne(Clone)").gameObject;
        //playerTwoPrefab = transform.Find("PlayerTwo(Clone)").gameObject;
        /*
        playerOne = PlayerInput.Instantiate(playerOnePrefab, controlScheme: "PlayerOne", pairWithDevice: Keyboard.current);
        playerTwo = PlayerInput.Instantiate(playerTwoPrefab, controlScheme: "PlayerTwo", pairWithDevice: Keyboard.current);
        */
    }

    private void Update()
    {
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
