﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Floor;


public class Stage1MapController : IStageMapController
{
    // Start is called before the first frame update
    void Start()
    {
        time = 0;

        doorOrdersList = new List<List<bool>>();
        List<bool> do1 = new List<bool>();
        do1.Add(false);
        do1.Add(true);
        doorOrdersList.Add(do1);
        doors[0].gameObject.GetComponentInChildren<DoorTrigger>().goalTimeZone = 0;
        List<bool> do2 = new List<bool>();
        do2.Add(false);
        do2.Add(true);
        doorOrdersList.Add(do2);
        doors[1].gameObject.GetComponentInChildren<DoorTrigger>().goalTimeZone = 0;

        capsuleOrdersList = new List<List<bool>>();
        List<bool> ca1 = new List<bool>();
        ca1.Add(true);
        ca1.Add(false);
        capsuleOrdersList.Add(ca1);
        capsules[0].gameObject.GetComponentInChildren<TimeCapsule>().goalTimeZone = 1;
        StartTimeZone(1);
        fadeInOut = Panel.GetComponent<EffectManager>();
        Debug.Log(fadeInOut);
    }

    public override void StartTimeZone(int state)
    {
        curTimeZone = state;
        if (state == 0)
        {
            ordersList = new List<List<FloorOrder>>();

            List<FloorOrder> po1 = new List<FloorOrder>();
            po1.Add(new FloorOrder(FloorStates.Idle, 3.0f));
            po1.Add(new FloorOrder(FloorStates.Backward, 4.0f));
            po1.Add(new FloorOrder(FloorStates.Idle, 3.0f));
            po1.Add(new FloorOrder(FloorStates.Forward, 4.0f));
            ordersList.Add(po1);

            List<FloorOrder> po2 = new List<FloorOrder>();
            po2.Add(new FloorOrder(FloorStates.Idle, 3.0f));
            po2.Add(new FloorOrder(FloorStates.Left, 4.0f));
            po2.Add(new FloorOrder(FloorStates.Idle, 3.0f));
            po2.Add(new FloorOrder(FloorStates.Right, 4.0f));
            ordersList.Add(po2);

            List<FloorOrder> po3 = new List<FloorOrder>();
            po3.Add(new FloorOrder(FloorStates.Idle, 3.0f));
            po3.Add(new FloorOrder(FloorStates.Up, 4.0f));
            po3.Add(new FloorOrder(FloorStates.Idle, 3.0f));
            po3.Add(new FloorOrder(FloorStates.Down, 4.0f));
            ordersList.Add(po3);

        }
        else if(state == 1)
        {
            ordersList = new List<List<FloorOrder>>();

            List<FloorOrder> po1 = new List<FloorOrder>();
            po1.Add(new FloorOrder(FloorStates.Idle, 3.0f));
            po1.Add(new FloorOrder(FloorStates.Backward, 8.0f));
            po1.Add(new FloorOrder(FloorStates.Idle, 3.0f));
            po1.Add(new FloorOrder(FloorStates.Forward, 8.0f));
            ordersList.Add(po1);

            List<FloorOrder> po2 = new List<FloorOrder>();
            po2.Add(new FloorOrder(FloorStates.Idle, 3.0f));
            po2.Add(new FloorOrder(FloorStates.Left, 8.0f));
            po2.Add(new FloorOrder(FloorStates.Idle, 3.0f));
            po2.Add(new FloorOrder(FloorStates.Right, 8.0f));
            ordersList.Add(po2);

            List<FloorOrder> po3 = new List<FloorOrder>();
            po3.Add(new FloorOrder(FloorStates.Idle, 3.0f));
            po3.Add(new FloorOrder(FloorStates.Down, 4.0f));
            po3.Add(new FloorOrder(FloorStates.Idle, 3.0f));
            po3.Add(new FloorOrder(FloorStates.Up, 4.0f));
            ordersList.Add(po3);

        }
        OrderSystemOnline();
    }
    public override void EndTimeZone(int state)
    {
        //
    }
    public override void ChangeTimeZone(int currentState, int nextState)
    {
        if(currentState == 0 && nextState == 1)
        {
            //동면할때
        }
        else if(currentState == 1 && nextState == 0)
        {
            //문을 통과할때
            //fadeInOut.StartFadeIn();
            //fadeInOut.StartFadeOut();
            //fadeInOut.StartFadeInOut();
        }
        publicState = nextState;
        StartCoroutine("timeChange");
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
   
}
