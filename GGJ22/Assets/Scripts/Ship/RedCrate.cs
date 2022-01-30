using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RedCrate : MonoBehaviour
{

    GameController gameController;
    public void Setup(float timeToReachBottom, GameController gController)
    {

        gameController = gController;
        gameController.movementController.ButtonPressed += Move;
        transform.DOMoveY(-6.7f, timeToReachBottom).SetEase(Ease.Linear).OnComplete(() => Destruction());
    }

    void Destruction()
    {
        //gameController.MeteorReachedBottom();
        gameController.movementController.ButtonPressed -= Move;
        Destroy(gameObject);
    }
    

   void Move(string param)
    {
        Debug.Log("Pressed!" + param);

        switch (param)
        {

            case "Red":
                transform.DOMoveX(1.6f, 0.2f).SetEase(Ease.Linear);
                break;

            case "Blue":
                transform.DOMoveX(-1.6f, 0.2f).SetEase(Ease.Linear);
                break;

            case "Center":
                transform.DOMoveX(0, 0.2f).SetEase(Ease.Linear);
                break;

            default:
                break;
        }
    }

}
