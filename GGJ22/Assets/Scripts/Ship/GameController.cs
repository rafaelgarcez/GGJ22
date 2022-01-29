using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    [SerializeField] MeteorSpawnManager meteorSpawnManager;

    public bool InvertControls = false;
    public int Score = 0;
    public bool IsGameRunning = true;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] GameObject startBtn;

    public void GameStart()
    {
        IsGameRunning = true;
        startBtn.SetActive(false);
        meteorSpawnManager.SpawnMeteor();
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
        
        Score++;
        scoreTxt.text = Score.ToString();
        
        Debug.Log("Ganhou um ponto!");
    }

    public void Death()
    {
        IsGameRunning = false;
    }
    
}
