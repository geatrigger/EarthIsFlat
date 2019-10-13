using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDisappear : MonoBehaviour
{
    MeshRenderer myRenderer;
    BoxCollider myCollider;
    int curTimeZone;
    bool disappearState;
    public GameObject disappearEffect;
    GameObject disappearEffectObject;
    public Texture[] brokenTexture;
    public Texture[] normalTexture;
    
    // Start is called before the first frame update
    void Awake()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myCollider = GetComponent<BoxCollider>();
        
    }
    private void Start()
    {
        
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
        Debug.Log("11");
        if (disappearState && other.gameObject.name == "Player")
        {
            disappearEffectObject = Instantiate<GameObject>(disappearEffect);
            StartCoroutine(ShowAndHide(gameObject, 2.0f));
        }
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
        if (other.gameObject.name == "Player")
        {
            StopCoroutine(ShowAndHide(gameObject, 2.0f));
            StartCoroutine(Show(gameObject, 5.0f));
        }

    }
    public void OrderToDisappearFloor(bool state, int timeZone)
    {
        curTimeZone = timeZone;
        disappearState = state; // true if disappears
        if(state == true)
        {
            myRenderer.materials[0].SetTexture(1, brokenTexture[0]);
            myRenderer.materials[1].SetTexture(1, brokenTexture[1]);
        }
        else
        {
            myRenderer.materials[0].SetTexture(1, normalTexture[0]);
            myRenderer.materials[1].SetTexture(1, normalTexture[1]);
        }

    }



    // Update is called once per frame
    void Update()
    {
        if(disappearEffectObject != null)
            disappearEffectObject.transform.position = gameObject.transform.position;
    }
}
