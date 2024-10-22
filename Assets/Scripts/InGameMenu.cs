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
    public GameObject options;
    public GameObject menu;

    [Header("Main Menu Buttons")]
    public Button menuButton;
    public Button optionButton;
    public Button quitButton;
    public Button resumeButton;

    public InputActionProperty StartPress;

    public List<Button> returnButtons;

    // Start is called before the first frame update
    private void Awake()
    {
        menu.SetActive(false);
    }
    void Update()
    {
        menu.SetActive(true);
        if (StartPress.action.triggered)
        {
            ShowMenu();
        }
        //Hook events
        menuButton.onClick.AddListener(MainMenu);
        optionButton.onClick.AddListener(EnableOption);
        quitButton.onClick.AddListener(QuitGame);
        resumeButton.onClick.AddListener(ResumeGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    private void ShowMenu()
    {
        Debug.Log("button pressed");
        menu.SetActive(true);
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
        options.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
    }
    public void EnableOption()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
   
}
