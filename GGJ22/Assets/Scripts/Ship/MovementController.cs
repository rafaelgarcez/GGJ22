using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] Transform ship;
    [SerializeField] float movementSpeed;
    [SerializeField] Transform[] positions;
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

    void moveShip() => ship.position = Vector2.MoveTowards(ship.position, target.position, movementSpeed * Time.deltaTime);

    void CheckDestination()
    {
        if (motion == MOTION.LEFT && ship.position.x == positions[0].position.x)
        {
            motion = MOTION.STOPPED;
            return;
        }

        if (motion == MOTION.CENTER && ship.position.x == positions[1].position.x)
        {
            motion = MOTION.STOPPED;
            return;
        }

        if (motion == MOTION.RIGHT && ship.position.x == positions[2].position.x)
            motion = MOTION.STOPPED;
    }

    void GetMovement()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
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
        motion = MOTION.RIGHT;
        target = positions[2];
    }

    void MoveToLeft()
    {
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
