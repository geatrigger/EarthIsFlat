﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 30.0f;
    public float runSpeed = 60.0f;
    float curSpeed;
    float accel = 10.0f;
    float decel = 10.0f;
    public Transform cameraTransform;
    bool enableJump = true;

    CharacterController characterController = null;

    //중력
    float yVelocity = 0.0f;
    public float gravity = -10.0f;
    //점프
    public float jumpSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    //현재 이동 방향, 기존 이동방향
    Vector3 moveDirection =new Vector3(0, 0, 0);
    Vector3 tempDirection = new Vector3(0, 0, 0);
    Vector3 movingFloor = new Vector3(0, 0, 0);
    GameObject movingObject;
    //점프 한번만
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(hit.moveDirection.x + hit.moveDirection.y + hit.moveDirection.z);
        if(hit.moveDirection.y <= -1 || hit.moveDirection.y >= -0.95)
        {
            enableJump = true;
            accel = 10.0f;
        }
        //Debug.Log(hit.collider);
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("MovingFloor"))
        {
            movingObject = hit.collider.gameObject;
        }
        else movingObject = null;
        //

    }


// Update is called once per frame
void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // running
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            curSpeed = runSpeed;
            /*if (curSpeed < runSpeed)
            {
                curSpeed += accel * Time.deltaTime;
            }
            if (moveDirection.x == x && moveDirection.z == z)
            {
                tempDirection = moveDirection;
            }*/
        }
        //walking
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            curSpeed = moveSpeed;
            /*if (curSpeed < moveSpeed)
            {

                curSpeed += accel * Time.deltaTime;
            }
            else//running -> walking
            {
                curSpeed -= decel * Time.deltaTime;
            }
            if (moveDirection.x == x && moveDirection.z == z)
            {
                tempDirection = moveDirection;
            }*/
        }
        else
        {
            /*moveDirection = tempDirection;
            if (curSpeed > 0)
            {
                curSpeed -= decel * Time.deltaTime;
            }
            else curSpeed = 0;*/
        }
        moveDirection = new Vector3(x, 0, z);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= curSpeed;

        if (Input.GetButtonDown("Jump") && enableJump == true)
        {
            yVelocity = jumpSpeed;
            enableJump = false;
        }
        if (yVelocity > -20.0f)
        {
            yVelocity += gravity * Time.deltaTime;
        }
        moveDirection.y = yVelocity;
        characterController.Move(moveDirection * Time.deltaTime);
        if (movingObject && movingObject.layer == LayerMask.NameToLayer("MovingFloor"))
        {
            movingFloor = movingObject.GetComponent<FloorMovement>().GetMoveDistance();
            characterController.Move(movingFloor * Time.deltaTime);
            
        }
        movingFloor = new Vector3(0, 0, 0);

        if(characterController.collisionFlags == CollisionFlags.Below)
        {
            yVelocity = 0.0f;
        }
    }
}
