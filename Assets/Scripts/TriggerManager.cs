using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TriggerManager : MonoBehaviour
{
    public GameObject text;
    bool[] checkTrigger = new bool[30];
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        for (int i = 0; i < 30; i++)
        {
            checkTrigger[i] = true;
        }
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
                    Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
                    /*other.GetComponent<PlayerController>().moveDirection = new Vector3(0.0f, 0.0f, 0.0f);
                    CharacterController controller = other.GetComponent<CharacterController>();
                    controller.enabled = false;
                    other.transform.position = new Vector3(0, 10.0f, 0);
                    controller.enabled = true;*/
                }
                break;
            case "Tuto_trigger_0":
                if (other.gameObject.layer == LayerMask.NameToLayer("Player") && checkTrigger[0] == true)
                {
                    StartCoroutine(Tuto_trigger_0());
                    checkTrigger[0] = false;
                }
                break;
            case "Tuto_trigger_1":
                if (other.gameObject.layer == LayerMask.NameToLayer("Player") && checkTrigger[1] == true)
                {
                    StartCoroutine(Tuto_trigger_1());
                    checkTrigger[1] = false;
                }
                break;
            case "Tuto_trigger_2":
                if (other.gameObject.layer == LayerMask.NameToLayer("Player") && checkTrigger[2] == true)
                {
                    StartCoroutine(Tuto_trigger_2());
                    checkTrigger[2] = false;

                }
                break;
            case "Tuto_trigger_3":
                if (other.gameObject.layer == LayerMask.NameToLayer("Player") && checkTrigger[3] == true)
                {
                    StartCoroutine(Tuto_trigger_3());
                    checkTrigger[3] = false;

                }
                break;
            case "Tuto_trigger_4":
                if (other.gameObject.layer == LayerMask.NameToLayer("Player") && checkTrigger[4] == true)
                {
                    StartCoroutine(Tuto_trigger_4());
                    checkTrigger[4] = false;

                }
                break;
            case "Tuto_trigger_5":
                if (other.gameObject.layer == LayerMask.NameToLayer("Player") && checkTrigger[5] == true)
                {
                    StartCoroutine(Tuto_trigger_5());
                    checkTrigger[5] = false;

                }
                break;
            case "Start_trigger":
                if (other.gameObject.layer == LayerMask.NameToLayer("Player") && checkTrigger[6] == true)
                {
                    StartCoroutine(Start_trigger());
                    checkTrigger[6] = false;

                }
                break;
        }

    }

    IEnumerator Start_trigger()
    {
        text.SetActive(true);
        text.GetComponentInChildren<Text>().text = "캐릭터 조작 : wasd\n점프 : space bar\n달리기 : shift\n상호작용 : E";

        yield return new WaitForSeconds(3.0f);
        text.SetActive(false);
    }
    IEnumerator Tuto_trigger_0()
    {
        text.SetActive(true);
        text.GetComponentInChildren<Text>().text = "<튜토리얼 1>\n\n낡은 발판은 부셔집니다.\n빠르게 통과해야 합니다.";

        yield return new WaitForSeconds(2.0f);
        text.SetActive(false);
    }
    IEnumerator Tuto_trigger_1()
    {
        text.SetActive(true);
        text.GetComponentInChildren<Text>().text = "<튜토리얼 2>\n\n움직이는 발판이 낡아 통과할 수 없습니다.\n문을 통과해 가속해서 시간을 되돌려\n낡은 발판을 복구할 수 있습니다.";

        yield return new WaitForSeconds(4.0f);
        text.SetActive(false);
    }
    IEnumerator Tuto_trigger_2()
    {
        text.SetActive(true);
        text.GetComponentInChildren<Text>().text = "<튜토리얼 3>\n\n시간을 되돌리기 전에는 부서져 있던 벽이\n과거로 가며 복구되어 통과할 수 없게 됬습니다.\n하지만 머지않아 부셔질 것 같네요.\n캡슐에 접근해 동면함으로서\n미래로 갈 수 있습니다.";

        yield return new WaitForSeconds(5.0f);
        text.SetActive(false);
    }

    IEnumerator Tuto_trigger_3()
    {
        text.SetActive(true);
        text.GetComponentInChildren<Text>().text = "<튜토리얼 4>\n\n버튼이 망가져서 작동하지 않습니다.\n시간을 되돌려서 버튼이 잘 작동하던 때로\n돌아가서 버튼을 작동시킬 수 있습니다.";

        yield return new WaitForSeconds(4.0f);
        text.SetActive(false);
    }
    IEnumerator Tuto_trigger_4()
    {
        text.SetActive(true);
        text.GetComponentInChildren<Text>().text = "<튜토리얼 5>\n\n시간을 되돌리면서 방비시설까지 작동하게 되었습니다.\n미래로 가서 시설의 작동을 다시 멈출 수 있습니다.";

        yield return new WaitForSeconds(4.0f);
        text.SetActive(false);
    }
    IEnumerator Tuto_trigger_5()
    {
        text.SetActive(true);
        text.GetComponentInChildren<Text>().text = "<튜토리얼 6>\n\n목표 지점에 도착했습니다.\n다음 스테이지로 진행 할 수 있습니다.";

        yield return new WaitForSeconds(3.0f);
        text.SetActive(false);
    }
}
