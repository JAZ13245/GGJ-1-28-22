using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        var p1 = PlayerInput.Instantiate(playerOnePrefab,
    controlScheme: "PlayerOne", device: Keyboard.current);
        var p2 = PlayerInput.Instantiate(playerTwoPrefab,
            controlScheme: "PlayerTwo", device: Keyboard.current);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
