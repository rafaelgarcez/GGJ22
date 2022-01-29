using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemMovementController : MonoBehaviour
{

    public Transform SelectedItem;
    [SerializeField] Transform startPosition;
    
    public void MoveToCenter()
    {
        SelectedItem.position = startPosition.position;
        SelectedItem.DOMoveX(0, 0.5f);
    }

    public void MoveToRight()
    {
        SelectedItem.DOMoveX(10, 0.5f);
    }

}
