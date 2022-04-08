using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public enum ButtonType
    {
        Return, Keyboard, Controller
    }
    public OptionButton[] buttons;
    public int currentSelection;
    private int selectedButton = 0;
    public static string controls = "Keyboard";
    public GameObject warning;

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
            if ((Options.controls == "Keyboard" && Keyboard.current.leftArrowKey.wasPressedThisFrame) || (Options.controls == "Gamepad" && Gamepad.current.leftStick.left.wasPressedThisFrame))
            {
                if (!buttons[currentSelection].selected)
                {
                    buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                }
                currentSelection++;
            }

            if ((Options.controls == "Keyboard" && Keyboard.current.rightArrowKey.wasPressedThisFrame) || (Options.controls == "Gamepad" && Gamepad.current.leftStick.right.wasPressedThisFrame))
            {
                if (!buttons[currentSelection].selected)
                {
                    buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                }
                currentSelection = 2;
            }
        }

        else if(currentSelection == 1)
        {
            if (((Options.controls == "Keyboard" && Keyboard.current.leftArrowKey.wasPressedThisFrame) || (Options.controls == "Gamepad" && Gamepad.current.leftStick.left.wasPressedThisFrame)) || 
                ((Options.controls == "Keyboard" && Keyboard.current.rightArrowKey.wasPressedThisFrame) || (Options.controls == "Gamepad" && Gamepad.current.leftStick.right.wasPressedThisFrame)))
            {
                if (!buttons[currentSelection].selected)
                {
                    buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                }
                currentSelection = 2;
            }

            if ((Options.controls == "Keyboard" && Keyboard.current.upArrowKey.wasPressedThisFrame) || (Options.controls == "Gamepad" && Gamepad.current.leftStick.up.wasPressedThisFrame))
            {
                if (!buttons[currentSelection].selected)
                {
                    buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                }
                currentSelection = 0;
            }
        }

        else if (currentSelection == 2)
        {
            if (((Options.controls == "Keyboard" && Keyboard.current.leftArrowKey.wasPressedThisFrame) || (Options.controls == "Gamepad" && Gamepad.current.leftStick.left.wasPressedThisFrame)) ||
                ((Options.controls == "Keyboard" && Keyboard.current.rightArrowKey.wasPressedThisFrame) || (Options.controls == "Gamepad" && Gamepad.current.leftStick.right.wasPressedThisFrame)))
            {
                if (!buttons[currentSelection].selected)
                {
                    buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                }
                currentSelection = 1;
            }

            if ((Options.controls == "Keyboard" && Keyboard.current.upArrowKey.wasPressedThisFrame) || (Options.controls == "Gamepad" && Gamepad.current.leftStick.up.wasPressedThisFrame))
            {
                if (!buttons[currentSelection].selected)
                {
                    buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
                }
                currentSelection = 0;
            }
        }
        if (selectedButton != 0)
        {
            buttons[selectedButton].button.GetComponent<SpriteRenderer>().color = Color.red;
        }
        buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.blue;
        //Debug.Log(Gamepad.current.leftStick.ReadValue());

        if ((Options.controls == "Keyboard" && Keyboard.current.enterKey.wasPressedThisFrame) || (Options.controls == "Gamepad" && Gamepad.current.aButton.wasPressedThisFrame))
        {
            switch (buttons[currentSelection].buttonType)
            {
                case ButtonType.Return:
                    SceneManager.LoadScene("StartMenu");
                    break;
                case ButtonType.Keyboard:
                    buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.red;
                    buttons[currentSelection].selected = true;
                    buttons[2].selected = false;
                    selectedButton = currentSelection;
                    buttons[2].button.GetComponent<SpriteRenderer>().color = Color.white;
                    warning.SetActive(false);
                    controls = "Keyboard";
                    break;
                case ButtonType.Controller:
                    if(Gamepad.current != null)
                    {
                        buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.red;
                        buttons[currentSelection].selected = true;
                        buttons[1].selected = false;
                        selectedButton = currentSelection;
                        buttons[1].button.GetComponent<SpriteRenderer>().color = Color.white;
                        warning.SetActive(false);
                        controls = "Gamepad";
                        if (Gamepad.current is UnityEngine.InputSystem.XInput.XInputController)
                        {
                            Debug.Log("Xbox");
                        }
                        if (Gamepad.current is UnityEngine.InputSystem.DualShock.DualShockGamepad)
                        {
                            Debug.Log("Playstation");
                        }
                        if (Gamepad.current is UnityEngine.InputSystem.Switch.SwitchProControllerHID)
                        {
                            Debug.Log("Switch");
                        }
                    }
                    else
                    {
                        warning.SetActive(true);
                    }
                    break;
                default:
                    Debug.Log("Error: no menu button selection");
                    break;
            }
        }
    }

    [System.Serializable]
    public class OptionButton
    {
        public GameObject button;
        public ButtonType buttonType;
        public bool selected = false;
    }
}
