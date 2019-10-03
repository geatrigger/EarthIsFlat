using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //other.GetComponent<PlayerController>().moveDirection = new Vector3(0.0f, 0.0f, 0.0f);
            CharacterController controller = other.GetComponent<CharacterController>();
            controller.enabled = false;
            other.transform.position = new Vector3(0, 10.0f, 0);
            controller.enabled = true;
        }
    }
}
