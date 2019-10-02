using System.Collections;
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
    GameObject Player;
    //중력
    float yVelocity = 0.0f;
    public float gravity = -20.0f;
    //점프
    public float jumpSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        characterController = GetComponent<CharacterController>();
    }
    //현재 이동 방향, 기존 이동방향
    Vector3 moveDirection =new Vector3(0, 0, 0);
    Vector3 tempDirection = new Vector3(0, 0, 0);
    Vector3 movingFloor = new Vector3(0, 0, 0);

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("isEnter!");
        if (other.gameObject.layer == 9)
        {
            //This will make the player a child of the Obstacle
            Player.transform.parent = other.gameObject.transform; //Change "myPlayer" to your player
        }
    }

    private void OnCollisionExit(Collision other)
    {
        Player.transform.parent = null;
    }

    //점프 한번만
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(hit.moveDirection.x + hit.moveDirection.y + hit.moveDirection.z);
        if(hit.moveDirection.y <= -1 || hit.moveDirection.y >= -0.85)
        {
            enableJump = true;
            accel = 10.0f;
        }
        //Debug.Log(hit.gameObject.layer);
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("MovingFloor"))
        {  
            movingFloor = hit.collider.gameObject.GetComponent<FloorMovement>().GetMoveDistance();
        }
        

    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(curSpeed);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // running
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection = new Vector3(x, 0, z);
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
            moveDirection = new Vector3(x, 0, z);
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
            moveDirection = tempDirection;
            if (curSpeed > 0)
            {
                curSpeed -= decel * Time.deltaTime;
            }
            else curSpeed = 0;
        }
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= curSpeed;

        if (Input.GetButtonDown("Jump") && enableJump == true)
        {
            yVelocity = jumpSpeed;
            accel = 5.0f;
            enableJump = false;
        }
        yVelocity += gravity * Time.deltaTime;
        moveDirection.y = yVelocity;
        characterController.Move(moveDirection * Time.deltaTime);
        characterController.Move(movingFloor * Time.deltaTime);

        movingFloor = new Vector3(0, 0, 0);

        if(characterController.collisionFlags == CollisionFlags.Below)
        {
            yVelocity = 0.0f;
        }
        

    }

}
