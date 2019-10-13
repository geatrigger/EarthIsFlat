using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TriggerManager : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (name)
        {
            case "belowTrigger":
                if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    other.GetComponent<PlayerController>().moveDirection = new Vector3(0.0f, 0.0f, 0.0f);
                    CharacterController controller = other.GetComponent<CharacterController>();
                    controller.enabled = false;
                    other.transform.position = new Vector3(0, 10.0f, 0);
                    controller.enabled = true;
                }
                break;
            case "Tuto_trigger_1":
                if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    StartCoroutine(Tuto_trigger_1());
                    
                }
                break;
            case "Tuto_trigger_2":
                if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
                {

                }
                break;
        }
        
    }

    IEnumerator Tuto_trigger_1()
    {
        text.SetActive(true);
        text.GetComponent<Text>().text = "test1";
        
        yield return new WaitForSeconds(2.0f);
        text.SetActive(false);
    }

}
