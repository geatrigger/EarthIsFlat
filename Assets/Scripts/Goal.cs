using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string nextScene;
    public GameObject text;
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
            CharacterController controller = other.GetComponent<CharacterController>();
            controller.enabled = false;
            text.SetActive(true);
            //GameOverText.enabled = true;
            text.GetComponentInChildren<Text>().text = "You Win!";
            SceneManager.LoadScene(nextScene);
        }
    }
}
