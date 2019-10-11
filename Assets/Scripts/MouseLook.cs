using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    float sensitivity = 700.0f;

    float rotationX = 0;
    float rotationY = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouserMoveValueX = Input.GetAxis("Mouse X");
        float mouserMoveValueY = Input.GetAxis("Mouse Y");

        rotationX += mouserMoveValueX * sensitivity * Time.deltaTime;
        rotationY += mouserMoveValueY * sensitivity * Time.deltaTime;

        rotationY = Mathf.Clamp(rotationY, -50.0f, 60.0f);

        transform.eulerAngles = new Vector3(-rotationY, rotationX, 0.0f);

    }
}
