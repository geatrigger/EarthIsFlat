using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string nextScene;
    public Image panel;
    public Text GameOverText;
    // Start is called before the first frame update
    void Start()
    {
        panel.enabled = false;
        GameOverText.enabled = false;
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
            GameOverText.text = "=!=TEST_SUCCESS=!=";
            panel.enabled = true;
            GameOverText.enabled = true;
            SceneManager.LoadScene(nextScene);
        }
    }
}
