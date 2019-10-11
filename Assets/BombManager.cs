using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    float time;
    bool PlayerIsHit;
    GameObject Player;
    Vector3 hitdir;
    // Start is called before the first frame update
    void Start()
    {
        PlayerIsHit = false;
        time=0.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Player = collision.gameObject;
            //do something
            PlayerIsHit = true;
            hitdir = collision.gameObject.transform.position - transform.position;
            

            Debug.Log(hitdir);
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * 3000.0f);

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (PlayerIsHit == true)
        {

            StartCoroutine("pushPlayer");
        }
        time += Time.deltaTime;
        if (time > 3.0 && PlayerIsHit == false)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator pushPlayer()
    {
        time = 0.0f;
        while (time < 0.5)
        {
            hitdir.y = 2.0f * Mathf.Lerp(1.0f, -0.5f, time*2);
            time += Time.deltaTime;
            Player.transform.Translate(hitdir * 1.0f * Time.deltaTime);

            yield return null;

        }
        PlayerIsHit = false;


        Destroy(this.gameObject);
    }

}
