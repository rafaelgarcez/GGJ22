using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Obstacle":
                Debug.Log("Morreu!");
                break;

            case "Point":
                Debug.Log("Ganhou um ponto!");
                break;

            default:
                break;
        }

        /*
        if (col.tag == "Obstacle")
        {
            Debug.Log("Colidiu!");
        }
        */
    }
}
