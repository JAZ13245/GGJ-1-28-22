using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public bool touchingPlayerOne, touchingPlayerTwo;
    Color targetColor, baseColor;

    // Start is called before the first frame update
    void Start()
    {
        baseColor = GetComponent<SpriteRenderer>().color;
        targetColor = new Color(baseColor.r, baseColor.g, baseColor.b, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        Color currentColor = GetComponent<SpriteRenderer>().color;
        if (touchingPlayerOne || touchingPlayerTwo)
        {
            targetColor = new Color(baseColor.r, baseColor.g, baseColor.b, 0.5f);
        }
        else
        {
            targetColor = new Color(baseColor.r, baseColor.g, baseColor.b, 1);
        }

        if(Mathf.Abs(currentColor.a - targetColor.a) > 0.04f)
        {
            if (targetColor.a == 1){
                GetComponent<SpriteRenderer>().color = new Color(baseColor.r, baseColor.g, baseColor.b,
                    currentColor.a+.01f);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(baseColor.r, baseColor.g, baseColor.b,
                    currentColor.a - .01f);
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = targetColor;
        }

        // if somehow passed target, set to target color
        //if(currentColor.a > targetColor.a || currentColor.a < targetColor.a)
        //{ GetComponent<SpriteRenderer>().color = targetColor; }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        Debug.Log(c.gameObject.name);
        // if colliding with either player, true
        if (c.gameObject.name.Contains("PlayerOne")) { touchingPlayerOne = true; }
        if (c.gameObject.name.Contains("PlayerTwo")) { touchingPlayerTwo = true; }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        // if leaving collision with either player, false
        if (c.gameObject.name.Contains("PlayerOne")) { touchingPlayerOne = false; }
        if (c.gameObject.name.Contains("PlayerTwo")) { touchingPlayerTwo = false; }

    }
}
