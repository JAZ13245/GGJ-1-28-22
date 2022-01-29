using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        var player1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "PlayerOne", pairWithDevice: Keyboard.current);
        var player2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "PlayerTwo", pairWithDevice: Keyboard.current);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
