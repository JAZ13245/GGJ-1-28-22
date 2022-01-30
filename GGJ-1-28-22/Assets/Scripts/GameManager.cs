using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;

    public PlayerInput playerOne;
    public PlayerInput playerTwo;

    public SpawnBlock spawnBlock;
    public LevelLoader level;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        playerOne = PlayerInput.Instantiate(playerOnePrefab, controlScheme: "PlayerOne", pairWithDevice: Keyboard.current);
        playerTwo = PlayerInput.Instantiate(playerTwoPrefab, controlScheme: "PlayerTwo", pairWithDevice: Keyboard.current);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
