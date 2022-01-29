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
        var player1 = PlayerInput.Instantiate(playerOnePrefab, controlScheme: "PlayerOne", pairWithDevice: Keyboard.current);
        var player2 = PlayerInput.Instantiate(playerTwoPrefab, controlScheme: "PlayerTwo", pairWithDevice: Keyboard.current);
        player2.gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
