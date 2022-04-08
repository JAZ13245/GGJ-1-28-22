using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour
{
    public enum ButtonType
    {
        Start, Options, Exit
    }
    public MenuButton[] buttons;
    public int currentSelection;
    public Color selectionColor;
    //public List<GameObject> buttons;
    //public List<ButtonType> buttonTypes;

    // Start is called before the first frame update
    void Start()
    {
        currentSelection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int temp = 0;
        
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame || (Options.controls == "Gamepad" && Gamepad.current.leftStick.left.wasPressedThisFrame)) { 
            temp--;
            buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log("New Menu Selection: " + currentSelection + " aka " + buttons[currentSelection].buttonType);
        }
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame || (Options.controls == "Gamepad" && Gamepad.current.rightStick.left.wasPressedThisFrame)) { 
            temp++;
            buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log("New Menu Selection: " + currentSelection + " aka " + buttons[currentSelection].buttonType);
        }
        currentSelection += temp;
        
        if(currentSelection >= buttons.Length) {
            currentSelection = 0;
        }
        else if (currentSelection < 0) {
            currentSelection = buttons.Length - 1;
        }
        buttons[currentSelection].button.GetComponent<SpriteRenderer>().color = selectionColor;
        Debug.Log(selectionColor);


        if (Input.GetKey(KeyCode.Return))
        {
            switch(buttons[currentSelection].buttonType)
            {
                case ButtonType.Start:
                    SceneManager.LoadScene("Level01");
                    break;
                case ButtonType.Options:
                    SceneManager.LoadScene("Options");
                    break;
                case ButtonType.Exit:
                    Application.Quit();
                    break;
                default:
                    Debug.Log("Error: no menu button selection");
                    break;
            }
        }
    }
    
    [System.Serializable]
    public class MenuButton
    {
        public GameObject button;
        public ButtonType buttonType;
    }
}
