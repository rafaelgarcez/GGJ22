using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] MeteorSpawnManager meteorSpawnManager;

    public bool InvertControls = false;
    public int Score = 0;
    public bool IsGameRunning = true;

    public void GameStart()
    {

    }


    public void MeteorReachedBottom()
    {
        if (!IsGameRunning)
            return;

        meteorSpawnManager.SpawnMeteor();

    }

    public void AddPoint()
    {
        if (!IsGameRunning)
            return;

        Debug.Log("Ganhou um ponto!");
    }

    public void Death()
    {
        IsGameRunning = false;
    }
    
}
