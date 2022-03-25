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

    public int currentSelection;
    public List<GameObject> buttons;
    public List<ButtonType> buttonTypes;

    // Start is called before the first frame update
    void Start()
    {
        currentSelection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int temp = 0;
        if (Input.GetKeyDown(KeyCode.UpArrow)) { 
            temp--;
            buttons[currentSelection].GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log("New Menu Selection: " + currentSelection + " aka " + buttonTypes[currentSelection]);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { 
            temp++;
            buttons[currentSelection].GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log("New Menu Selection: " + currentSelection + " aka " + buttonTypes[currentSelection]);
        }
        currentSelection += temp;

        if(currentSelection >= buttons.Count) {
            currentSelection = 0;
        }
        else if (currentSelection < 0) {
            currentSelection = buttons.Count - 1;
        }
        buttons[currentSelection].GetComponent<SpriteRenderer>().color = Color.red;


        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch(buttonTypes[currentSelection])
            {
                case ButtonType.Start:
                    SceneManager.LoadScene("Level01");
                    break;
                case ButtonType.Options:
                    break;
                case ButtonType.Exit:
                    break;
                default:
                    Debug.Log("Error: no menu button selection");
                    break;
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
