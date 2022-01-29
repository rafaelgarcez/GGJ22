using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Meteor : MonoBehaviour
{

    public void Setup(float timeToReachBottom)
    {
        transform.DOMoveY(-6.7f, timeToReachBottom).SetEase(Ease.Linear).OnComplete(() => Destroy(gameObject));
    }

}
