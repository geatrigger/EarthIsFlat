using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCapsule : MonoBehaviour
{
    public int goalTimeZone;
    public int curTimeZone;
    Stage1MapController map;
    Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map").GetComponent<Stage1MapController>();
        initPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickObject()
    {
        map.ChangeTimeZone(curTimeZone, goalTimeZone);
    }

    public void OrderToTimeCapsule(bool state, int timeZone)
    {
        curTimeZone = timeZone;
        gameObject.transform.position = initPos;
        gameObject.SetActive(state);
    }
}
