using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDisappear : MonoBehaviour
{
    MeshRenderer myRenderer;
    BoxCollider myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myCollider = GetComponent<BoxCollider>();
    }
    IEnumerator ShowAndHide(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        myRenderer.enabled = false;
        myCollider.enabled = false;

    }
    IEnumerator Show(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        myRenderer.enabled = true;
        myCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ShowAndHide(gameObject, 2.0f));
    }
    /* void OnTriggerStay(Collider other)
    {
        if(myRenderer.enabled == false)
        {
            StopCoroutine(ShowAndHide(gameObject, 2.0f));
            StartCoroutine(Show(gameObject, 5.0f));
        }
    }*/
    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(ShowAndHide(gameObject, 2.0f));
        StartCoroutine(Show(gameObject, 5.0f));

    }



    // Update is called once per frame
    void Update()
    {

    }
}
