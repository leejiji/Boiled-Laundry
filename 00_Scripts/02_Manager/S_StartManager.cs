using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class S_StartManager : MonoBehaviour
{
    [SerializeField] GameObject PlayerObj;
    [SerializeField] Animator animator;
    [SerializeField] Animator UI_animator;

    S_GameManager gameManager;
    S_SceneManager _sceneManagaer;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<S_GameManager>();
        S_SoundManager.Instance.PlayBGMSound();

        if (PlayerPrefs.HasKey("Day") && PlayerPrefs.HasKey("Happy") && PlayerPrefs.HasKey("Money"))
        {
            if(PlayerPrefs.GetString("Day") == "0")
                gameManager.so_Object.setDay("00");
            else
                gameManager.so_Object.setDay(PlayerPrefs.GetString("Day"));

            gameManager.so_Player.setMoney(PlayerPrefs.GetInt("Money"), 1);
            gameManager.so_Player.setHappy( PlayerPrefs.GetInt("Happy"), 1);
        }
        else
        {
            gameManager.so_Object.setDay("00");
            gameManager.so_Player.setMoney(30000, 1);
            gameManager.so_Player.setHappy(50, 1);

        }
    }

    private void Start()
    {
        _sceneManagaer = GameObject.Find("GameManager").GetComponent<S_SceneManager>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("터치");
            StartCoroutine(StartAni());
        }
    }

    IEnumerator StartAni()
    {
        //페이드아웃
        UI_animator.Play("00_StartAni");
        yield return new WaitForSeconds(1f);
        S_SoundManager.Instance.PlaySFXSound(0);
        animator.Play("00_StartScene");
        yield return new WaitForSeconds(2f);
        PlayerObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        StartCoroutine(_sceneManagaer.LoadScene("01_GameScene"));
    }
}
