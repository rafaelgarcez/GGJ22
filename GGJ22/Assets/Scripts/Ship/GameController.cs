using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using FMODUnity;

public class GameController : MonoBehaviour
{
    public MovementController movementController;
    [SerializeField] BGM_Manager bGM_Manager;
    [SerializeField] SpawnManager meteorSpawnManager;
    [SerializeField] Ship ship;
    [SerializeField] Transform shipvisual;
    [SerializeField] GameObject GameOverText;
    //  [SerializeField] SpriteRenderer flash;
    [SerializeField] Animator explosionAnimator;
    [SerializeField] GameObject howToPlay;

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
        howToPlay.SetActive(false);
        shipvisual.DOMoveY(-3.3f, 0.5f).From(-10f).SetEase(Ease.OutBack);
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
       // flash.gameObject.SetActive(true);
        //flash.DOFade(0.27f, 0.2f).From(0).OnComplete(() => flash.gameObject.SetActive(false));
        //flash.DOFade(0.27f, 0.2f).From(0).OnComplete(() => flash.DOFade(0, 0.2f).From(0.27f));
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
        RuntimeManager.PlayOneShot("event:/Explosao");
        explosionAnimator.transform.position = ship.transform.position;
        explosionAnimator.Play("Explosion");
        IsGameRunning = false;
        //ship.gameObject.SetActive(false);
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
