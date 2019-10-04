using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{

    public GameObject toActive;
    Vector3 speed = new Vector3(0.0f, 0.0f, 0.0f);
    float checkTime=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void moveCube()
    {
        switch (toActive.name)
        {
            case "testWall":
                speed = new Vector3(0.0f, 1.0f, 0.0f);
                Debug.Log("help");
                checkTime = 0.0f;
        
                break;
            case "Button2":
                break;

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        checkTime += Time.deltaTime;
        if(checkTime<7.0f)
        toActive.transform.Translate(speed *Time.deltaTime);
        else
        {
            checkTime = 0.0f;
            speed = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
