using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Floor;

public abstract class IStageMapController : MonoBehaviour
{
    public List<GameObject> movingPlatforms;
    public List<GameObject> doors;
    public List<GameObject> capsules;
    public List<GameObject> disappearingPlatforms;
    public List<GameObject> disappearingWalls;
    public List<List<FloorOrder>> ordersList;
    public List<List<bool>> doorOrdersList;
    public List<List<bool>> capsuleOrdersList;
    public List<List<bool>> disappearingOrdersList;
    public List<List<bool>> disappearingWallOrdersList;
    public Image Panel;
    protected int curTimeZone;
    protected int publicState;
    protected EffectManager fadeInOut;
    protected float time;
     // Start is called before the first frame update
     void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public abstract void StartTimeZone(int state);
    public abstract void EndTimeZone(int state);
    public abstract void ChangeTimeZone(int currentState, int nextState);
    public void OrderSystemOnline()
    {
        int index = -1;
        foreach (GameObject platform in movingPlatforms)
        {
            index++;
            Debug.Log(ordersList.Count);
            if (ordersList.Count > index)
            {
                platform.gameObject.GetComponent<FloorMovement>().OrderToFloor(ordersList[index]);
            }
            else
            {
                index--;
            }
        }
        index = -1;
        foreach (GameObject door in doors)
        {
            index++;
            door.gameObject.GetComponentInChildren<DoorTrigger>().OrderToDoor(doorOrdersList[index][curTimeZone], curTimeZone);
        }
        index = -1;
        foreach (GameObject capsule in capsules)
        {
            index++;
            capsule.gameObject.GetComponentInChildren<TimeCapsule>().OrderToTimeCapsule(capsuleOrdersList[index][curTimeZone], curTimeZone);
        }
        index = -1;
        foreach (GameObject platform in disappearingPlatforms)
        {
            index++;
            platform.gameObject.GetComponentInChildren<FloorDisappear>().OrderToDisappearFloor(disappearingOrdersList[index][0], curTimeZone);
        }
        index = -1;
        foreach (GameObject wall in disappearingWalls)
        {
            index++;
            Debug.Log(disappearingWallOrdersList.Count);
            wall.gameObject.GetComponentInChildren<WallMovement>().OrderToWall(disappearingWallOrdersList[index][0], curTimeZone);
        }
        return;
    }
    public virtual IEnumerator timeChange()
    {
        fadeInOut.StartFadeOut();
        yield return new WaitForSeconds(2.0f);
        StartTimeZone(publicState);
        fadeInOut.StartFadeIn();
    }
}
