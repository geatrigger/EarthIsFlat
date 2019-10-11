using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    GameObject Player;
    GameObject Model;
    Vector3 ModelPos;

    float sensitivity = 700.0f;

    float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = transform.parent.gameObject;
        Model = this.gameObject;
        ModelPos = transform.position- Player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Model.transform.position = Player.transform.position;
        float mouserMoveValueX = Input.GetAxis("Mouse X");
        
        rotationX += mouserMoveValueX * sensitivity * Time.deltaTime;
        transform.eulerAngles = new Vector3(0.0f, rotationX, 0.0f);
        Vector3 NewModelPos = Quaternion.Euler(0f, rotationX, 0f) * ModelPos;
        Model.transform.position = Player.transform.position+ NewModelPos; 
    }
}
