using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] Transform ship;
    [SerializeField] float movementSpeed;
    [SerializeField] Transform[] positions;
    MOTION motion;
    Transform target;

    void Update()
    {
        GetMovement();
        CheckDestination();
        if (motion != MOTION.STOPPED)
            moveShip();
    }

    void moveShip()
    {
        ship.position = Vector2.MoveTowards(ship.position, target.position, movementSpeed * Time.deltaTime);
    }

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
            motion = MOTION.LEFT;
            target = positions[0];
            return;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            motion = MOTION.RIGHT;
            target = positions[2];
            return;
        }
    }


    public enum MOTION
    {
        STOPPED,
        CENTER,
        LEFT,
        RIGHT
    }

}
