using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public float sensitivity = 700.0f;

    float rotationX = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float mouserMoveValueX = Input.GetAxis("Mouse X");

        rotationX += mouserMoveValueX * sensitivity * Time.deltaTime;


        transform.eulerAngles = new Vector3(0, rotationX, 0.0f);
    }
}
