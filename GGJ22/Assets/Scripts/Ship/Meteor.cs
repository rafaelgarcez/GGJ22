using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Meteor : MonoBehaviour
{

    public void Setup(float timeToReachBottom,GameController gameController)
    {
        transform.DOMoveY(-6.7f, timeToReachBottom).SetEase(Ease.Linear).OnComplete(() => Destruction(gameController));
    }

    void Destruction(GameController gameController) 
    {
        gameController.MeteorReachedBottom();
        Destroy(gameObject);

    }

}
