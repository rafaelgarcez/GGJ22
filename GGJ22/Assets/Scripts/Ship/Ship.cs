using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] GameController gameController;

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Obstacle":
                Debug.Log("Morreu!");
                gameController.Death();
                break;

            case "Point":

                gameController.AddPoint();
                break;

            default:
                break;
        }
    }
}
