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
    public List<Sprite> buttonSprites;
    public List<Vector3> buttonTransforms;
    public List<ButtonType> buttonTypes;

    // Start is called before the first frame update
    void Start()
    {
        currentSelection = 0;
        CreateButtons();
    }

    // Update is called once per frame
    void Update()
    {
        int temp = 0;
        if (Input.GetKeyDown(KeyCode.UpArrow)) { temp--; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { temp++; }
        currentSelection += temp;

        if(currentSelection >= buttons.Count) {
            currentSelection = 0;
        }
        else if (currentSelection < 0) {
            currentSelection = buttons.Count - 1;
        }

        Debug.Log(currentSelection);
    }

    private void CreateButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i] = Instantiate(new GameObject());
            buttons[i].AddComponent<SpriteRenderer>();
            buttons[i].GetComponent<SpriteRenderer>().sprite = buttonSprites[i];
            buttons[i].transform.position = buttonTransforms[i];
        }
    }


    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
