using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetStageFromUI : MonoBehaviour
{

    public Button startButton;
    public Button trainingButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(Set_Forest);
        trainingButton.onClick.AddListener(Set_Training);
    }

    void Set_Forest()
    {

        SceneManager.LoadScene("Foret");
    }
    void Set_Training()
    {
        SceneManager.LoadScene("Hangar");
    }
}
