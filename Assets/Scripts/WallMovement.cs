using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public GameObject me;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OrderToWall(bool state)
    {
        me.SetActive(state);
        //달리 할게 없음
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
