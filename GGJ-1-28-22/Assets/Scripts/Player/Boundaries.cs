using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float playerWidth;
    private float playerHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 3;
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 3;
    }

    void LateUpdate()
    {
        Vector3 playerPositon = transform.position;
        playerPositon.x = Mathf.Clamp(playerPositon.x, screenBounds.x * -1 + playerWidth, screenBounds.x - playerWidth);
        playerPositon.y = Mathf.Clamp(playerPositon.y, screenBounds.y * -1 + playerHeight, screenBounds.y - playerHeight);
        transform.position = playerPositon;
    }
}
