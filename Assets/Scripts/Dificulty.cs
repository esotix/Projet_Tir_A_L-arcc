using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dificulty : MonoBehaviour
{
    [Header("Main Menu Buttons")]
    public Button Easy;
    public Button Normal;
    public Button Hard;

    public int difficulty = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Easy.onClick.AddListener(SetEasy);
        Normal.onClick.AddListener(SetNormal);
        Hard.onClick.AddListener(SetHard);
    }

    void SetEasy()
    {
        difficulty = 0;
    }
    void SetNormal()
    {
        difficulty = 1;
    }
    void SetHard()
    {
        difficulty = 2;
    }
}
