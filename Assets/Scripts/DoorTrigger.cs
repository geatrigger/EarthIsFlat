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
    GameObject player;
    GameObject portalCamera;


    public float sensitivity = 700.0f;

    float rotationX = 0;
    float rotationY = 0;

    // Start is called before the first frame update
    void Awake()
    {
        map = GameObject.Find("Map").GetComponent<IStageMapController>();
        initPos = me.transform.position;


        portalCamera = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame  
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player = other.gameObject;
            other.gameObject.GetComponent<PlayerController>().doorCnt++;
            CharacterController controller = other.GetComponent<CharacterController>();
            controller.enabled = false;
            other.transform.position = otherDoor.transform.position + otherDoor.transform.forward * forwardFactor;
            Rigidbody playerRigid = other.gameObject.GetComponent<Rigidbody>();
            //playerRigid.velocity = new Vector3(playerRigid.velocity.x, 0, playerRigid.velocity.z);
            controller.enabled = true;
            if (other.gameObject.GetComponent<PlayerController>().doorCnt >= 3)
            {
                StartCoroutine("ChangeTimeAnimation");
            }
            else
            {

            }
        }
    }



    IEnumerator ChangeTimeAnimation()
    {
        map.ChangeTimeZone(curTimeZone, goalTimeZone);

        float time = 0f;
        while (time<=2.0f)
        {
            time += Time.deltaTime;
            player.transform.Translate(otherDoor.transform.forward * 2.0f * time);
            //fadeColor.a = Mathf.Lerp(start, end, time);
            //myImage.color = fadeColor;
            yield return null;
        }
        player.transform.position = otherDoor.transform.position + otherDoor.transform.forward * forwardFactor + new Vector3(0.0f, 1.0f, 0.0f);
        player.gameObject.GetComponent<PlayerController>().doorCnt = 0;
    }
    public void OrderToDoor(bool state, int timeZone)
    {
        curTimeZone = timeZone;
        me.transform.position = initPos;
        me.SetActive(state);
    }
}
