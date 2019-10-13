using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    public float FadeTime = 2f; // Fade효과 재생시간

    Image myImage;

    float start;

    float end;

    float time = 0f;

    bool isPlaying = false;
    GameObject player;
    PlayerController playerController;
    MouseLook playerMouse;
    RobotMovement robotMove;
    Animator robotAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
        myImage.enabled = false;
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        playerMouse = player.GetComponentInChildren<MouseLook>();
        robotMove = player.GetComponentInChildren<RobotMovement>();
        robotAnimator = player.GetComponentInChildren<Animator>();
    }

    public void StartFadeIn()
    {
        if(isPlaying == true)
        {
            return;
        }
        myImage.enabled = true;
        start = 1.0f;
        end = 0.0f;
        Debug.Log("imhere");
        StartCoroutine("fadeIn");
    }
    public void StartFadeOut()
    {
        if (isPlaying == true)
        {
            return;
        }
        myImage.enabled = true;
        start = 0.0f;
        end = 1.0f;
        Debug.Log("imhere");
        StartCoroutine("fadeOut");
    }
    IEnumerator fadeIn()
    {
        isPlaying = true;

        Color fadeColor = myImage.color;
        fadeColor.a = 1.0f;
        time = 0f;
        while(fadeColor.a > 0.0f)
        {
            time += Time.deltaTime;
            fadeColor.a = Mathf.Lerp(start, end, time);
            myImage.color = fadeColor;
            yield return null;
        }
        isPlaying = false;
        fadeColor.a = 1.0f;
        myImage.color = fadeColor;
        myImage.enabled = false;
        playerController.enabled = true;
        playerMouse.enabled = true;
        robotMove.enabled = true;
    }
    IEnumerator fadeOut()
    {
        Debug.Log("1111");
        robotAnimator.SetInteger("isWhat", 3);
        playerController.enabled = false;
        playerMouse.enabled = false;
        robotMove.enabled = false;
        isPlaying = true;

        Color fadeColor = myImage.color;
        fadeColor.a = 0.0f;
        time = 0f;
        while (fadeColor.a < 1.0f)
        {
            time += Time.deltaTime;
            fadeColor.a = Mathf.Lerp(start, end, time);
            myImage.color = fadeColor;
            yield return null;
        }
        isPlaying = false;
        //fadeColor.a = 0.0f;
        //myImage.color = fadeColor;
        //myImage.enabled = false; //페이드아웃 하고 화면 까만 상태 유지하려면 이거 키면 됨.
        //yield return new WaitForSeconds(2.0f);

        //StartCoroutine("fadeIn");
    }


    public void StartFadeInOut()
    {

        Debug.Log("imalsohere");
        StartCoroutine("fadeInOut");
    }

    IEnumerator fadeInOut()
    {
        StartFadeOut();
        yield return new WaitForSeconds(2.0f);
        StartFadeIn();
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
