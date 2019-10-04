using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{

    public GameObject toActive;
    Vector3 speed = new Vector3(0.0f, 0.0f, 0.0f);
    float checkTime = 0.0f;
    bool[] acting = new bool[10];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            acting[i] = true;
        }

    }
    public void moveCube()
    {

        switch (name)
        {
            case "Button1":
                speed = new Vector3(0.0f, 1.0f, 0.0f);
                checkTime = 0.0f;
                Debug.Log("22222");
                break;
            case "Button2":
                break;

        }

    }
    // Update is called once per frame
    void Update()
    {
        if (acting[0] == true)
        {
            if (checkTime < 7.0f)
            {
                Debug.Log("33333");
                toActive.transform.Translate(speed * Time.deltaTime);
                checkTime += Time.deltaTime;
            }
            else if (checkTime >= 7.0f && speed.sqrMagnitude != 0.0f)
            {
                acting[0] = false;
                checkTime = 0.0f;
                speed = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }
    }

    public void OrderToButton()
    {

    }
}
