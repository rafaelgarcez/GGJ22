using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public MovementController movementController;
    [SerializeField] BGM_Manager bGM_Manager;
    [SerializeField] SpawnManager meteorSpawnManager;
    [SerializeField] Ship ship;
    [SerializeField] GameObject GameOverText;

    public bool InvertControls = false;
    public int Score = 0;
    int swapCount = 0;
    int nextSwapIn = 0;
    public bool IsGameRunning = true;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] GameObject startBtn;

    public void GameStart()
    {
        Score = 0;
        GameOverText.SetActive(false);
        nextSwapIn = Random.Range(3, 8);
        IsGameRunning = true;
        startBtn.SetActive(false);
        ship.gameObject.SetActive(true);
        InvertControls = false;
        scoreTxt.text = "0";
        movementController.ResetAll();
        meteorSpawnManager.StartTimer();
        bGM_Manager.StopMenuTheme();
    }


    public void MeteorReachedBottom()
    {
        if (!IsGameRunning)
            return;

        swapCount++;

        if (swapCount >= nextSwapIn)
        {
            swapCount = 0;
            nextSwapIn = Random.Range(3, 8);
            meteorSpawnManager.SpawnSwap();
        }


    }

    public void Swap()
    {
        //ship.SwapColors();
        InvertControls = !InvertControls;
        movementController.ColorSwap();
    }

    public void AddPoint()
    {
        if (!IsGameRunning)
            return;

        Score++;
        scoreTxt.text = Score.ToString();
    }

    public void Death()
    {
        IsGameRunning = false;
        ship.gameObject.SetActive(false);
        GameOverText.SetActive(true);
        bGM_Manager.StartMenuTheme();
        StartCoroutine(ShowPlay());
    }


    IEnumerator ShowPlay()
    {
        yield return new WaitForSeconds(2);
        startBtn.SetActive(true);
       
    }

}
