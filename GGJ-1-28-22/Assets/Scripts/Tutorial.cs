using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public bool touchingPlayer;
    Color targetColor;

    // Start is called before the first frame update
    void Start()
    {
        targetColor = new Color(1f, 1f, 1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        Color currentColor = GetComponent<SpriteRenderer>().color;
        if (touchingPlayer)
        {
            targetColor = new Color(1f, 1f, 1f, 0.5f);
        }
        else
        {
            targetColor = new Color(1f, 1f, 1f, 1);
        }

        if(Mathf.Abs(currentColor.a - targetColor.a) > 0.04f)
        {
            if (targetColor.a == 1){
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f,1f,
                    currentColor.a+.01f);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f,1f,
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
        if (c.gameObject.name.Contains("PlayerOne")) { touchingPlayer = true; }
        if (c.gameObject.name.Contains("PlayerTwo")) { touchingPlayer = true; }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        // if leaving collision with either player, false
        if (c.gameObject.name.Contains("PlayerOne")) { touchingPlayer = false; }
        if (c.gameObject.name.Contains("PlayerTwo")) { touchingPlayer = false; }

    }
}
