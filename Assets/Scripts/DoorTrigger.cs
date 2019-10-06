using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject otherDoor;
    public GameObject me;
    float forwardFactor = 3.0f;
    public int goalTimeZone;
    public int curTimeZone;
    IStageMapController map;
    Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map").GetComponent<IStageMapController>();
        initPos = me.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            controller.enabled = false;
            other.transform.position = otherDoor.transform.position + otherDoor.transform.forward * forwardFactor;
            Rigidbody playerRigid = other.gameObject.GetComponent<Rigidbody>();
            //playerRigid.velocity = new Vector3(playerRigid.velocity.x, 0, playerRigid.velocity.z);
            controller.enabled = true;
            map.ChangeTimeZone(curTimeZone, goalTimeZone);
        }
    }

    public void OrderToDoor(bool state, int timeZone)
    {
        curTimeZone = timeZone;
        me.transform.position = initPos;
        me.SetActive(state);
    }
}
