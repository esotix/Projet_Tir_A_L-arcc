using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrow;  // Le prefab de la fl�che
    public GameObject notch;  // L'objet o� la fl�che doit �tre attach�e

    private XRGrabInteractable _bow;
    private bool _arrowNotched = false;
    private GameObject _currentArrow = null;




    // Start is called before the first frame update
    void Start()
    {
        _bow = GetComponent<XRGrabInteractable>();
        PullInteraction.PullActionReleased += NotchEmpty;
    }

    private void OnDestroy()
    {
        PullInteraction.PullActionReleased -= NotchEmpty;
    }

    // Update is called once per frame
    void Update()
    {
        if (_bow.isSelected && !_arrowNotched)
        {
            _arrowNotched = true;
            StartCoroutine("DelayedSpawn");
        }

        // Si la fl�che est encoch�e et existe, actualiser sa position et sa rotation


        // Si l'arc n'est plus s�lectionn�, d�truire la fl�che et r�initialiser
        if (!_bow.isSelected && _currentArrow != null)
        {
            Destroy(_currentArrow);
        }
    }

    private void NotchEmpty(float value)
    {
        _arrowNotched = false;
        _currentArrow = null;
    }

    IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(1f);

        // Instancier la fl�che
        _currentArrow = Instantiate(arrow, notch.transform);

        // Ajuster imm�diatement la position et la rotation de la fl�che

    }


}