using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float runSpeed;
    float curSpeed;
    float accel = 10.0f;
    float decel = 10.0f;
    public Transform cameraTransform;
    bool enableJump = true;

    CharacterController characterController = null;

    public int doorCnt;
    //중력
    float yVelocity = 0.0f;
    public float gravity;
    //점프
    public float jumpSpeed;

    //현재 이동 방향, 기존 이동방향
    public Vector3 moveDirection = new Vector3(0, 0, 0);
    Vector3 tempDirection = new Vector3(0, 0, 0);
    Vector3 movingFloor = new Vector3(0, 0, 0);
    GameObject movingObject;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        doorCnt = 0;
    }


    //점프 한번만
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(hit.moveDirection.x + hit.moveDirection.y + hit.moveDirection.z);
        if(hit.moveDirection.y >= -1 && hit.moveDirection.y <= -0.95)
        {
            enableJump = true;
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
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
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
            doorCnt = 0;
            /*moveDirection = tempDirection;
            if (curSpeed > 0)
            {
                curSpeed -= decel * Time.deltaTime;
            }
            else curSpeed = 0;*/
        }
        moveDirection = new Vector3(x, 0, z);

        if (Input.GetButtonDown("Jump") && enableJump == true)
        {
            movingObject = null;
            yVelocity = jumpSpeed;
            enableJump = false;
        }
        if (yVelocity > -20.0f)
        {
            yVelocity += gravity * Time.deltaTime;
        }

        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= curSpeed;
        moveDirection.y = yVelocity;

        characterController.Move(moveDirection * Time.deltaTime);
        if (movingObject && movingObject.layer == LayerMask.NameToLayer("MovingFloor"))
        {
            movingFloor = movingObject.GetComponent<FloorMovement>().GetMoveDistance();
            characterController.Move(movingFloor * Time.deltaTime);

        }
        movingFloor = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.E))
        {
            target = GetClickedObject();
            if (target == null){ }
            else if (target.layer == LayerMask.NameToLayer("Button"))
            {
                target.GetComponent<ButtonTrigger>().moveCube();
            }
            else if (target.layer == LayerMask.NameToLayer("TimeCapsule"))
            {
                target.GetComponent<TimeCapsule>().ClickObject();
            }
        }
        if (characterController.collisionFlags == CollisionFlags.Below)
        {
            yVelocity = 0.0f;
        }
    }
    private GameObject GetClickedObject()
    {

        RaycastHit hit;

        GameObject target = null;

        if (true == (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10.0f)))
        {

            target = hit.collider.gameObject;
        }
        return target;
    }
}
