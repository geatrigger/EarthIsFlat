using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    int curTimeZone;
    MeshRenderer m;
    BoxCollider b;

    // Start is called before the first frame update
    void Start()
    {
        m = GetComponent<MeshRenderer>();
        b = GetComponent<BoxCollider>();
    }
    public void OrderToWall(bool state, int timeZone)
    {
        m.enabled = state;
        b.enabled = state;
        curTimeZone = timeZone;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
