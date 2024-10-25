using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject menu;

    [Header("Main Menu Buttons")]
    public Button menuButton;
    public Button quitButton;
    public Button resumeButton;

    public InputActionProperty StartPress;


    // Start is called before the first frame update
    void Update()
    {

        //Hook events
        menuButton.onClick.AddListener(MainMenu);
        quitButton.onClick.AddListener(QuitGame);
        resumeButton.onClick.AddListener(ResumeGame);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        menu.SetActive(false);
    }
    public void MainMenu()
    {
        HideAll();
        SceneManager.LoadScene("MainMenu");
    }

    public void HideAll()
    {
        mainMenu.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
    }
   
}
