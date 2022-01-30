using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using FMODUnity;

public class MovementController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] Ship ship;
    [SerializeField] float movementSpeed;
    [SerializeField] Transform[] positions;

    [SerializeField] Color32 blueColor;
    [SerializeField] Color32 redColor;

    public Action<string> ButtonPressed;

    [SerializeField] SpriteRenderer leftSphere;
    [SerializeField] SpriteRenderer leftBar;
    [SerializeField] SpriteRenderer rightSphere;
    [SerializeField] SpriteRenderer rightBar;

    [SerializeField] Animator leftAnimator;
    [SerializeField] Animator rightAnimator;
    MOTION motion;
    Transform target;

    public void ResetAll()
    {
       //RuntimeManager.PlayOneShot()
        ResetColors();
        motion = MOTION.STOPPED;
        ship.CenterVisual();
        ship.transform.position = new Vector3(0, ship.transform.position.y, ship.transform.position.z);
    }

    private void Start()
    {
        ResetColors();       
    }

    public void SwapTest()
    {
        ColorSwap();
            
    }

     public void ColorSwap()
    {
        RuntimeManager.PlayOneShot("event:/Polaridade");
        if (gameController.InvertControls)
        {
            leftBar.color = leftSphere.color = redColor;
            rightBar.color = rightSphere.color = blueColor;
            leftAnimator.Play("RedStatic");
            rightAnimator.Play("BlueStatic");
        }
        else
        {
            leftAnimator.Play("BlueStatic");
            rightAnimator.Play("RedStatic");
            leftSphere.color = leftBar.color = blueColor;
            rightBar.color = rightSphere.color = redColor;
        }

        leftBar.transform.DOScale(24, 0.15f).From(35);
        rightBar.transform.DOScale(24, 0.15f).From(35);
        //swapTest = !swapTest;

    }

    void ResetColors()
    {
        leftSphere.color = blueColor;
        leftBar.color = blueColor;

        rightBar.color = rightSphere.color = redColor;
        leftAnimator.Play("BlueStatic");
        rightAnimator.Play("RedStatic");
    }

    void Update()
    {
        if (!gameController.IsGameRunning)
            return;

        GetMovement();
        CheckDestination();
        if (motion != MOTION.STOPPED)
            moveShip();
    }

    void moveShip() => ship.transform.position = Vector2.MoveTowards(ship.transform.position, target.position, movementSpeed * Time.deltaTime);

    void CheckDestination()
    {
        if (motion == MOTION.LEFT && ship.transform.position.x == positions[0].position.x)
        {
            motion = MOTION.STOPPED;
            ship.CenterVisual();
            return;
        }

        if (motion == MOTION.CENTER && ship.transform.position.x == positions[1].position.x)
        {
            motion = MOTION.STOPPED;
            ship.CenterVisual();
            return;
        }

        if (motion == MOTION.RIGHT && ship.transform.position.x == positions[2].position.x)
        {
            motion = MOTION.STOPPED;
            ship.CenterVisual();
        }
            
    }

    void GetMovement()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            ship.CenterVisual();
            motion = MOTION.CENTER;
            target = positions[1];
            ButtonPressed?.Invoke("Center");
            AnimateSphere(rightSphere.transform);
            AnimateSphere(leftSphere.transform);

            if (!gameController.InvertControls)
            {
                leftAnimator.Play("BlueOpen");
                rightAnimator.Play("RedOpen");
            }
            else
            {
                leftAnimator.Play("RedOpen");
                rightAnimator.Play("BlueOpen");
            }


                return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!gameController.InvertControls)
            {
                leftAnimator.Play("BlueOpen");
                MoveToLeft();
            }

            else
            {
                leftAnimator.Play("RedOpen");
                MoveToRight();
            }

            AnimateSphere(leftSphere.transform);

            return;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!gameController.InvertControls)
            {
                rightAnimator.Play("RedOpen");
                MoveToRight();
            }
            else
            {
                rightAnimator.Play("BlueOpen");
                MoveToLeft();
            }
                

           // ButtonPressed?.Invoke("red");
            AnimateSphere(rightSphere.transform);
            return;
        }
    }


    void MoveToRight()
    {
        RuntimeManager.PlayOneShot("event:/Abrindo");
        ship.RightVisual();
        motion = MOTION.RIGHT;
        target = positions[2];
    }

    void MoveToLeft()
    {
        RuntimeManager.PlayOneShot("event:/Abrindo");
        ship.LeftVisual();
        motion = MOTION.LEFT;
        target = positions[0];
    }

    void AnimateSphere(Transform Sphere)
    {
        Sphere.gameObject.SetActive(true);
        Sphere.DOScale(0.2661003f, 0.15f).From(0).OnComplete(() => Sphere.gameObject.SetActive(false));
    }


    public enum MOTION
    {
        STOPPED,
        CENTER,
        LEFT,
        RIGHT
    }

}
