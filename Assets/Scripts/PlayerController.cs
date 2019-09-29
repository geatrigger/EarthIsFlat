using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 25.0f;
    public float runSpeed = 40.0f;
    float curSpeed;
    float accel = 10.0f;
    float decel = 10.0f;
    public Transform cameraTransform;

    CharacterController characterController = null;

    //중력
    float yVelocity = 0.0f;
    public float gravity = -20.0f;
    //점프
    public float jumpSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    Vector3 moveDirection =new Vector3(0, 0, 0);
    Vector3 tempDirection = new Vector3(0, 0, 0);
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // running
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            if (moveDirection.x != x || moveDirection.z != z)
            {

            }
            if (curSpeed < runSpeed)
            {

                curSpeed += accel * Time.deltaTime;
            }
            if (moveDirection.x == x && moveDirection.z == z)
            {
                tempDirection = moveDirection;
            }
        }
        //walking
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            moveDirection = new Vector3(x, 0, z);
            if (curSpeed < moveSpeed)
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
            }
        }
        else
        {
            moveDirection = tempDirection;
            if (curSpeed > 0)
            {
                curSpeed -= decel * Time.deltaTime;
            }
            else curSpeed = 0;
        }
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= curSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpSpeed;
        }
        yVelocity += gravity * Time.deltaTime;
        moveDirection.y = yVelocity;
        characterController.Move(moveDirection * Time.deltaTime);

        if(characterController.collisionFlags == CollisionFlags.Below)
        {
            yVelocity = 0.0f;
        }
    }
}
