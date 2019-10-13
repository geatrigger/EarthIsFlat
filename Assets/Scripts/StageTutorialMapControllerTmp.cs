using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Floor;

public class StageTutorialMapControllerTmp : IStageMapController
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
        List<bool> do3 = new List<bool>();
        do3.Add(false);
        do3.Add(true);
        doorOrdersList.Add(do3);
        doors[2].gameObject.GetComponentInChildren<DoorTrigger>().goalTimeZone = 0;
        List<bool> do4 = new List<bool>();
        do4.Add(false);
        do4.Add(true);
        doorOrdersList.Add(do4);
        doors[3].gameObject.GetComponentInChildren<DoorTrigger>().goalTimeZone = 0;

        capsuleOrdersList = new List<List<bool>>();
        List<bool> ca1 = new List<bool>();
        ca1.Add(true);
        ca1.Add(false);
        capsuleOrdersList.Add(ca1);
        capsules[0].gameObject.GetComponentInChildren<TimeCapsule>().goalTimeZone = 1;
        List<bool> ca2 = new List<bool>();
        ca2.Add(true);
        ca2.Add(false);
        capsuleOrdersList.Add(ca2);
        capsules[1].gameObject.GetComponentInChildren<TimeCapsule>().goalTimeZone = 1;
        StartTimeZone(1);
        fadeInOut = Panel.GetComponent<EffectManager>();
    }

    public override void StartTimeZone(int state)
    {
        curTimeZone = state;
        if (state == 0)
        {
            ordersList = new List<List<FloorOrder>>();

            List<FloorOrder> po1 = new List<FloorOrder>();
            po1.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po1.Add(new FloorOrder(FloorStates.Forward, 3.5f));
            po1.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po1.Add(new FloorOrder(FloorStates.Backward, 3.5f));
            ordersList.Add(po1);

            List<FloorOrder> po2 = new List<FloorOrder>();
            po2.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po2.Add(new FloorOrder(FloorStates.Left, 3.93f, 9.0f));
            po2.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po2.Add(new FloorOrder(FloorStates.Right, 3.93f, 9.0f));
            ordersList.Add(po2);

            List<FloorOrder> po3 = new List<FloorOrder>();
            po3.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po3.Add(new FloorOrder(FloorStates.Left, 3.93f, 9.0f));
            po3.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po3.Add(new FloorOrder(FloorStates.Right, 3.93f, 9.0f));
            ordersList.Add(po3);

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

            disappearingWallOrdersList = new List<List<bool>>();
            List<bool> diw1 = new List<bool>();
            diw1.Add(true);
            disappearingWallOrdersList.Add(diw1);
            List<bool> diw2 = new List<bool>();
            diw2.Add(true);
            disappearingWallOrdersList.Add(diw2);
            List<bool> diw3 = new List<bool>();
            diw3.Add(true);
            disappearingWallOrdersList.Add(diw3);
            List<bool> diw4 = new List<bool>();
            diw4.Add(true);
            disappearingWallOrdersList.Add(diw4);

            disappearingButtonOrdersList = new List<List<bool>>();
            List<bool> dib1 = new List<bool>();
            dib1.Add(true);
            disappearingButtonOrdersList.Add(dib1);


            canonsList = new List<List<bool>>();
            List<bool> can1 = new List<bool>();
            can1.Add(true);
            canonsList.Add(can1);
            List<bool> can2 = new List<bool>();
            can2.Add(true);
            canonsList.Add(can2);
            List<bool> can3 = new List<bool>();
            can3.Add(true);
            canonsList.Add(can3);
            List<bool> can4 = new List<bool>();
            can4.Add(true);
            canonsList.Add(can4);
            List<bool> can5 = new List<bool>();
            can5.Add(true);
            canonsList.Add(can5);
            List<bool> can6 = new List<bool>();
            can6.Add(true);
            canonsList.Add(can6);
            List<bool> can7 = new List<bool>();
            can7.Add(true);
            canonsList.Add(can7);
            List<bool> can8 = new List<bool>();
            can8.Add(true);
            canonsList.Add(can8);
            List<bool> can9 = new List<bool>();
            can9.Add(true);
            canonsList.Add(can9);
            List<bool> can10 = new List<bool>();
            can10.Add(true);
            canonsList.Add(can10);
        }
        else if (state == 1)
        {
            ordersList = new List<List<FloorOrder>>();

            List<FloorOrder> po1 = new List<FloorOrder>();
            po1.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po1.Add(new FloorOrder(FloorStates.Forward, 3.5f));
            po1.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po1.Add(new FloorOrder(FloorStates.Backward, 3.5f));
            ordersList.Add(po1);

            List<FloorOrder> po2 = new List<FloorOrder>();
            po2.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po2.Add(new FloorOrder(FloorStates.Left, 3.93f, 9.0f));
            po2.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po2.Add(new FloorOrder(FloorStates.Right, 3.93f, 9.0f));
            ordersList.Add(po2);

            List<FloorOrder> po3 = new List<FloorOrder>();
            po3.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po3.Add(new FloorOrder(FloorStates.Left, 3.93f, 9.0f));
            po3.Add(new FloorOrder(FloorStates.Idle, 1.0f));
            po3.Add(new FloorOrder(FloorStates.Right, 3.93f, 9.0f));
            ordersList.Add(po3);

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

            disappearingWallOrdersList = new List<List<bool>>();
            List<bool> diw1 = new List<bool>();
            diw1.Add(false);
            disappearingWallOrdersList.Add(diw1);
            List<bool> diw2 = new List<bool>();
            diw2.Add(false);
            disappearingWallOrdersList.Add(diw2);
            List<bool> diw3 = new List<bool>();
            diw3.Add(false);
            disappearingWallOrdersList.Add(diw3);
            List<bool> diw4 = new List<bool>();
            diw4.Add(false);
            disappearingWallOrdersList.Add(diw4);

            disappearingButtonOrdersList = new List<List<bool>>();
            List<bool> dib1 = new List<bool>();
            dib1.Add(false);
            disappearingButtonOrdersList.Add(dib1);

            canonsList = new List<List<bool>>();
            List<bool> can1 = new List<bool>();
            can1.Add(false);
            canonsList.Add(can1);
            List<bool> can2 = new List<bool>();
            can2.Add(false);
            canonsList.Add(can2);
            List<bool> can3 = new List<bool>();
            can3.Add(false);
            canonsList.Add(can3);
            List<bool> can4 = new List<bool>();
            can4.Add(false);
            canonsList.Add(can4);
            List<bool> can5 = new List<bool>();
            can5.Add(false);
            canonsList.Add(can5);
            List<bool> can6 = new List<bool>();
            can6.Add(false);
            canonsList.Add(can6);
            List<bool> can7 = new List<bool>();
            can7.Add(false);
            canonsList.Add(can7);
            List<bool> can8 = new List<bool>();
            can8.Add(false);
            canonsList.Add(can8);
            List<bool> can9 = new List<bool>();
            can9.Add(false);
            canonsList.Add(can9);
            List<bool> can10 = new List<bool>();
            can10.Add(false);
            canonsList.Add(can10);
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
