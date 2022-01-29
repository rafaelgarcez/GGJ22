using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] Ship ship;
    [SerializeField] float movementSpeed;
    [SerializeField] Transform[] positions;

    [SerializeField] Transform blueBar;
        
    MOTION motion;
    Transform target;

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
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!gameController.InvertControls)
                MoveToLeft();
            else
                MoveToRight();

            return;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!gameController.InvertControls)
                MoveToRight();
            else
                MoveToLeft();
            return;
        }
    }


    void MoveToRight()
    {
        ship.RightVisual();
        motion = MOTION.RIGHT;
        target = positions[2];
    }

    void MoveToLeft()
    {
        ship.LeftVisual();
        motion = MOTION.LEFT;
        target = positions[0];
    }

    public enum MOTION
    {
        STOPPED,
        CENTER,
        LEFT,
        RIGHT
    }

}
