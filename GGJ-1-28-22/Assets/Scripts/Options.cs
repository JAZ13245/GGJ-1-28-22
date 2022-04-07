using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public enum ButtonType
    {
        Return, Keyboard1, Keyboard2, Controller1, Controller2
    }
    public OptionButton[] buttons;
    public int currentSelection;
    public string playerOneControls = "PlayerOne";
    public string playerTwoControls = "PlayerTwo";

    // Start is called before the first frame update
    void Start()
    {
        currentSelection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSelection == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                currentSelection = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                currentSelection = 2;
            }
        }

        else if (currentSelection == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                currentSelection = 3;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                currentSelection = 2;
            }
        }

        else if(currentSelection == 2)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                currentSelection = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                currentSelection = 4;
            }
        }

        if (currentSelection == 1 || currentSelection == 2)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                currentSelection += 2;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                currentSelection = 0;
            }
        }

        if(currentSelection == 3 || currentSelection == 4)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                currentSelection -= 2;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                currentSelection = 3;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                currentSelection = 4;
            }
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (buttons[currentSelection].buttonType)
            {
                case ButtonType.Return:
                    SceneManager.LoadScene("StartMenu");
                    break;
                case ButtonType.Keyboard1:
                    playerOneControls = "PlayerOne";
                    break;
                case ButtonType.Keyboard2:
                    playerTwoControls = "PlayerTwo";
                    break;
                case ButtonType.Controller1:
                    playerOneControls = "Controller";
                    break;
                case ButtonType.Controller2:
                    playerTwoControls = "Controller";
                    break;
                default:
                    Debug.Log("Error: no menu button selection");
                    break;
            }
        }
        buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    [System.Serializable]
    public class OptionButton
    {
        public GameObject button;
        public ButtonType buttonType;
    }
}
