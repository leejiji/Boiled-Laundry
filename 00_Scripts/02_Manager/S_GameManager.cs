using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameManager : MonoBehaviour
{
    public static S_GameManager instance = null;

    public SO_Object so_Object;
    public SO_Player so_Player;
    string tempDay = "00";

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (instance)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "01_GameScene" && tempDay != so_Object.DayCount)
        {
            PlayerPrefs.SetString("Day", so_Object.DayCount);
            PlayerPrefs.SetInt("Happy", so_Player.HappyCount);
            PlayerPrefs.SetInt("Money", so_Player.Money);
        }

        if(SceneManager.GetActiveScene().name == "01_GameScene")
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                int dayCount = int.Parse(so_Object.DayCount) + 1;
                so_Object.setDay(dayCount);

                if(11 < int.Parse(so_Object.DayCount))
                {
                    var gameManager = GameObject.Find("GameManager").GetComponent<S_GameManager>();

                    PlayerPrefs.DeleteAll();
                    gameManager.so_Object.setDay("00");
                    gameManager.so_Player.setMoney(30000, 1);
                    gameManager.so_Player.setHappy(50, 1);

                    var _sceneManagaer = GameObject.Find("UIManager").GetComponent<S_UIManager>();
                    _sceneManagaer.MainPanel();
                }
            }
        }
    }
}
