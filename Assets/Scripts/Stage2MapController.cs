using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Floor;

public class Stage2MapController : IStageMapController
{
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
            po1.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po1.Add(new FloorOrder(FloorStates.Backward, 4.0f));
            po1.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po1.Add(new FloorOrder(FloorStates.Forward, 4.0f));
            ordersList.Add(po1);

            List<FloorOrder> po2 = new List<FloorOrder>();
            po2.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po2.Add(new FloorOrder(FloorStates.Left, 4.0f, 18.0f));
            po2.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po2.Add(new FloorOrder(FloorStates.Right, 4.0f, 18.0f));
            ordersList.Add(po2);

            List<FloorOrder> po3 = new List<FloorOrder>();
            po3.Add(new FloorOrder(FloorStates.Idle, 2.0f));
            po3.Add(new FloorOrder(FloorStates.Forward, 4.0f, 15.0f));
            po3.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po3.Add(new FloorOrder(FloorStates.Backward, 4.0f, 15.0f));
            ordersList.Add(po3);


            List<FloorOrder> po4 = new List<FloorOrder>();
            po4.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po4.Add(new FloorOrder(FloorStates.Forward, 5.0f, 20.0f));
            po4.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po4.Add(new FloorOrder(FloorStates.Backward, 2.5f, 40.0f));
            ordersList.Add(po4);

            disappearingOrdersList = new List<List<bool>>();
            List<bool> di1 = new List<bool>();
            di1.Add(false);
            disappearingOrdersList.Add(di1);
            List<bool> di2 = new List<bool>();
            di2.Add(false);
            disappearingOrdersList.Add(di2);
            List<bool> di3 = new List<bool>();
            di3.Add(false);
            disappearingOrdersList.Add(di3);
            List<bool> di4 = new List<bool>();
            di4.Add(false);
            disappearingOrdersList.Add(di4);
            List<bool> di5 = new List<bool>();
            di5.Add(false);
            disappearingOrdersList.Add(di5);
            List<bool> di6 = new List<bool>();
            di6.Add(false);
            disappearingOrdersList.Add(di6);
            List<bool> di7 = new List<bool>();
            di7.Add(false);
            disappearingOrdersList.Add(di7);
        }
        else if (state == 1)
        {
            ordersList = new List<List<FloorOrder>>();

            List<FloorOrder> po1 = new List<FloorOrder>();
            po1.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po1.Add(new FloorOrder(FloorStates.Backward, 4.0f));
            po1.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po1.Add(new FloorOrder(FloorStates.Forward, 4.0f));
            ordersList.Add(po1);

            List<FloorOrder> po2 = new List<FloorOrder>();
            po2.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po2.Add(new FloorOrder(FloorStates.Left, 4.0f, 18.0f));
            po2.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po2.Add(new FloorOrder(FloorStates.Right, 4.0f, 18.0f));
            ordersList.Add(po2);

            List<FloorOrder> po3 = new List<FloorOrder>();
            po3.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po3.Add(new FloorOrder(FloorStates.Forward, 4.0f, 15.0f));
            po3.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po3.Add(new FloorOrder(FloorStates.Backward, 4.0f, 15.0f));
            ordersList.Add(po3);


            List<FloorOrder> po4 = new List<FloorOrder>();
            po4.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po4.Add(new FloorOrder(FloorStates.Forward, 5.0f, 20.0f));
            po4.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po4.Add(new FloorOrder(FloorStates.Backward, 2.0f, 50.0f));
            ordersList.Add(po4);

            disappearingOrdersList = new List<List<bool>>();
            List<bool> di1 = new List<bool>();
            di1.Add(true);
            disappearingOrdersList.Add(di1);
            List<bool> di2 = new List<bool>();
            di2.Add(true);
            disappearingOrdersList.Add(di2);
            List<bool> di3 = new List<bool>();
            di3.Add(true);
            disappearingOrdersList.Add(di3);
            List<bool> di4 = new List<bool>();
            di4.Add(true);
            disappearingOrdersList.Add(di4);
            List<bool> di5 = new List<bool>();
            di5.Add(true);
            disappearingOrdersList.Add(di5);
            List<bool> di6 = new List<bool>();
            di6.Add(true);
            disappearingOrdersList.Add(di6);
            List<bool> di7 = new List<bool>();
            di7.Add(true);
            disappearingOrdersList.Add(di7);
        }
        OrderSystemOnline(state);
    }
    public override void EndTimeZone(int state)
    {
        //
    }
    public override void ChangeTimeZone(int currentState, int nextState)
    {
        if (currentState == 0 && nextState == 1)
        {
            //동면할때
        }
        else if (currentState == 1 && nextState == 0)
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
