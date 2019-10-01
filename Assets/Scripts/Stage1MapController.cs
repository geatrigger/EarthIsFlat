using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Floor;
public class Stage1MapController : MonoBehaviour
{
    public List<GameObject> movingPlatforms;
    public List<List<FloorOrder>> ordersList;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
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

        OrderSystemOnline();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
    
    void OrderSystemOnline()
    {
        int index = -1;
        foreach (GameObject platform in movingPlatforms)
        {
            index++;
            if (ordersList.Count >= index)
            {
                platform.gameObject.GetComponent<FloorMovement>().OrderToFloor(ordersList[index]);
            }
            else
            {
                index--;
            }
        }
        return;
    }
}
