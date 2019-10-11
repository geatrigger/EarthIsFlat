using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    MeshRenderer myRenderer;
    BoxCollider myCollider;
    public GameObject brokenEffect;
    public GameObject[] toActives;
    public Vector3[] speed;
    float checkTime = 0.0f;
    bool[] acting = new bool[10];
    bool[] buttonChk = new bool[10];
    public Texture brokenTexture;
    public Texture normalTexture;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            acting[i] = false;
            buttonChk[i] = false;
        }
        myRenderer = GetComponent<MeshRenderer>();
        myCollider = GetComponent<BoxCollider>();
        brokenEffect.SetActive(false);

    }
    public void ClickObject()
    {

        switch (name)
        {
            case "Tuto_Button1":

                if (buttonChk[0] == false)
                {
                    acting[0] = true;
                    checkTime = 0.0f;
                    buttonChk[0] = true;
                }
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
                int count = 0;
                foreach (GameObject toActive in toActives)
                {
                    toActive.transform.Translate(speed[count] * Time.deltaTime);
                    count++;
                }
                checkTime += Time.deltaTime;
            }
            else if (checkTime >= 7.0f && speed[0].sqrMagnitude != 0.0f)
            {
                acting[0] = false;
                checkTime = 0.0f;
            }
        }
    }

    public void OrderToButton(bool state)
    {
        if (state != true)
        {
            myRenderer.material.SetColor("broken", Color.red);
            myCollider.enabled = state;
            brokenEffect.SetActive(true);
        }
        else
        {
            myRenderer.material.SetColor("normal", Color.green);
            myCollider.enabled = state;
            brokenEffect.SetActive(false);
        }

    }
}
