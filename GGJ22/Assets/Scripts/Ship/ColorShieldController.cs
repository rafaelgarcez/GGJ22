using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorShieldController : MonoBehaviour
{
    [SerializeField] MovementController movementController;
    [SerializeField] Transform blue;
    [SerializeField] Transform red;

    void Start()
    {
        movementController.ButtonPressed += ShowShield;
    }

    void ShowShield(string param)
    {

        /*
        switch (param)
        {

            case "Red":
                red.gameObject.SetActive(true);
                red.DOScale(0.01472682f, 0.15f).From(0).OnComplete(() => red.gameObject.SetActive(false));
                //transform.DOMoveX(1.6f, 0.2f).SetEase(Ease.Linear);
                break;

            case "Blue":
                blue.gameObject.SetActive(true);
                blue.DOScale(0.01472682f, 0.15f).From(0).OnComplete(() => blue.gameObject.SetActive(false)); 
                // transform.DOMoveX(-1.6f, 0.2f).SetEase(Ease.Linear);
                break;

            case "Center":
                red.gameObject.SetActive(false);
                blue.gameObject.SetActive(false);
                //transform.DOMoveX(0, 0.2f).SetEase(Ease.Linear);
                break;

            default:
                break;
        }

        */
    }


    private void OnDestroy()
    {
        movementController.ButtonPressed -= ShowShield;
    }
}
