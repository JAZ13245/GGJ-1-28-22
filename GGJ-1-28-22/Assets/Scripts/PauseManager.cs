using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    
    public static bool paused = false;
    public GameObject menu;

    PauseAction action;

    private void Awake()
    {
        action = new PauseAction();
    }

    private void OnEnable()
    {
        action.Enable();
        Time.timeScale = 1;
        paused = false;
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.Pause.PauseGame.performed += _ => DeterminePause();
    }

    private void DeterminePause()
    {
        if (paused)
            return;
        else
            PauseGame();
    }

    //pause game function
    public void PauseGame()
    {
        Time.timeScale = 0;
        paused = true;
        menu.SetActive(true);
    }

    //resume game function
    public void ResumeGame()
    {
        Time.timeScale = 1;
        paused = false;
        menu.SetActive(false);
    }
}
