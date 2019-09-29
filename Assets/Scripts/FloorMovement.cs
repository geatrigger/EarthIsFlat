using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public enum FloorStates
    {
        Idle,
        Forward,
        Backward,
        Right,
        Left,
        Up,
        Down
    }
    public FloorStates direction;
    public float floorSpeed = 10.0f;
    public Transform floorTransform;
    Vector3 moveDistance;
    
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Code For Move Test
        time += Time.deltaTime;
        if(time > 5.0f)
        {
            if (direction == FloorStates.Idle)
                direction = FloorStates.Forward;
            else if (direction == FloorStates.Forward)
                direction = FloorStates.Backward;
            else if (direction == FloorStates.Backward)
                direction = FloorStates.Idle;

            time -= 5.0f;
        }


        moveDistance = getMoveDistance(floorSpeed);
        floorTransform.Translate(moveDistance * Time.deltaTime);

    }

    private Vector3 getMoveDistance(float speed)
    {
        Vector3 moveDirection;
        switch (direction)
        {
            case FloorStates.Idle:
                moveDirection = new Vector3(0, 0, 0);
                break;
            case FloorStates.Forward:
                moveDirection = new Vector3(1, 0, 0);
                break;
            case FloorStates.Backward:
                moveDirection = new Vector3(-1, 0, 0);
                break;
            case FloorStates.Right:
                moveDirection = new Vector3(0, 0, 1);
                break;
            case FloorStates.Left:
                moveDirection = new Vector3(0, 0, -1);
                break;
            case FloorStates.Up:
                moveDirection = new Vector3(0, 1, 0);
                break;
            case FloorStates.Down:
                moveDirection = new Vector3(0, -1, 0);
                break;
            default:
                moveDirection = new Vector3(0, 0, 0);
                break;
        }
        moveDirection = floorTransform.TransformDirection(moveDirection);
        moveDirection *= speed;
        return moveDirection;
    }
    public Vector3 GetMoveDistance()
    {
        return moveDistance;
    }
}
