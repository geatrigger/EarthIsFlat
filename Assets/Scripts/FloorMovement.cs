﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Floor;

namespace Floor
{
    public class FloorOrder
    {
        //private static int f_idx = 0;
        //private int i;
        private FloorStates dir;
        private float cycleTime;
        private float speed;

        public FloorOrder(FloorStates direction, float cycle, float spd)
        {
            //i = f_idx++;
            dir = direction;
            cycleTime = cycle;
            speed = spd;
        }

        public FloorOrder(FloorStates direction, float cycle)
        {
            //i = f_idx++;
            dir = direction;
            cycleTime = cycle;
            speed = 10.0f;
        }

        public FloorStates GetDir()
        {
            return dir;
        }
        public float GetCycleTime()
        {
            return cycleTime;
        }
        public float GetFloorSpeed()
        {
            return speed;
        }
    }

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
}
public class FloorMovement : MonoBehaviour
{
    public FloorStates direction;
    public float floorSpeed = 10.0f;
    public Transform floorTransform;
    public Rigidbody floorRigidBody;
    public List<FloorOrder> orders;
    Vector3 initialPosition;
    int curOrderIdx;
    Vector3 moveDistance;
    float time = 0.0f;
    float cycleTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        floorRigidBody = GetComponent<Rigidbody>();
        curOrderIdx = -1;
        time = 0.01f;
        initialPosition = floorRigidBody.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //float remainTime = 0.0f;
        if(orders == null)
        {
            return;
        }
        // Code For Move Test
        time += Time.deltaTime;
        if (time >= cycleTime)
        {
            //remainTime = time - cycleTime;
            time = 0.0f;
        }
        moveDistance = getMoveDistance();
        floorTransform.Translate(moveDistance * (Time.deltaTime /*- remainTime*/ ));
        
        floorRigidBody.MovePosition(floorRigidBody.position += moveDistance * (Time.deltaTime /*- remainTime*/ ));
        if (time == 0.0f)
        {
            nextOrder();
        }
    }

    private Vector3 getMoveDistance()
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
        moveDirection *= floorSpeed;
        return moveDirection;
    }
    public Vector3 GetMoveDistance()
    {
        return moveDistance;
    }
    public void OrderToFloor(List<FloorOrder> Order)
    {
        orders = Order;
        if(orders.Count == 0)
        {
            orders = null;
            return;
        }
        curOrderIdx = -1;
        floorRigidBody.transform.position = initialPosition;
        nextOrder();
    }

    private void nextOrder()
    {
        if(curOrderIdx + 1 == orders.Count)
        {
            curOrderIdx = -1;
        }
        curOrderIdx++;
        //Debug.Log(curOrderIdx);
        cycleTime = orders[curOrderIdx].GetCycleTime();
        direction = orders[curOrderIdx].GetDir();
        floorSpeed = orders[curOrderIdx].GetFloorSpeed();
        //Debug.Log(direction);
    }
}
