using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaunchMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public InputActionProperty StartPress;

    void Update()
    {
        if (StartPress.action.triggered)
        {
            ShowMenu();
        }
    }
    private void ShowMenu()
    {
        mainMenu.SetActive(true);
    }
}
