using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public GameObject Canon;
    public GameObject CanonBall;

    Vector3 FireVector;
    Vector3 FirePosition;
    float timer =0.0f;
    float power = 20.0f;
    bool fire;
    // Start is called before the first frame update
    void Start()
    {
        fire = true;//or flase
        FireVector = Canon.transform.GetChild(0).transform.forward;
        FirePosition = Canon.transform.GetChild(0).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3.0f && fire)
        {
            GameObject obj = Instantiate(CanonBall);

            obj.transform.position = FirePosition;
            obj.GetComponent<Rigidbody>().velocity = FireVector * power;
            timer = 0.0f;
        }
    }

    public void OrderToCanon(bool state)
    {
        Canon.transform.GetChild(1).gameObject.SetActive(state);
        fire = state;

    }
}
