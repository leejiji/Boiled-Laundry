using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_MapScroll : MonoBehaviour
{
    [SerializeField] S_UIManager ui;

    [SerializeField] GameObject AllMap;
    [SerializeField] GameObject[] mapList = new GameObject[12];

    [SerializeField, Range(0f, 10f)] public float M_speed = 0f;

    [SerializeField] SO_Object so_Object;
    [SerializeField] SO_Player so_player;
    [SerializeField] SO_Setting so_Setting;

    public int mapNum = 0;
    float A_speed = 1;
    Vector3 last_Position;

    private void Awake()
    {
        so_Setting.SpeedSet(1);
        A_speed = so_Setting.Game_Speed;
        last_Position = new Vector3(mapList[mapList.Length-1].transform.position.x - 1.2f, 0f, 0f);
    }
    void Update()
    {
        if (so_Object.IsEnabled == false && so_player.IsMove)
        {
            AllMap.transform.Translate(-M_speed * Time.deltaTime * A_speed, 0, 0);
        }

        if(mapList[mapNum].transform.position.x <= -22f)
        {
            mapList[mapNum].transform.position = last_Position;
            last_Position = mapList[mapNum].transform.position;
            mapNum++;

            if (mapNum >= mapList.Length)
            {
                mapNum = 0;

                int dayCount = int.Parse(so_Object.DayCount) + 1;
                if(dayCount > 12)
                {
                    var gameManager = GameObject.Find("GameManager").GetComponent<S_GameManager>();

                    PlayerPrefs.DeleteAll();
                    gameManager.so_Object.setDay("00");
                    gameManager.so_Player.setMoney(30000, 1);
                    gameManager.so_Player.setHappy(50, 1);

                    var _sceneManagaer = GameObject.Find("UIManager").GetComponent<S_UIManager>();
                    _sceneManagaer.MainPanel();
                    //¿£µù
                }
                else
                {                    
                    so_Object.setDay(dayCount);
                }
            }
        }
    }

    public void SpeedSet(float _speed)
    {
        if(A_speed > 0.5f && _speed < 0)
        {
            A_speed -= 0.5f;
        }
        else if(A_speed < 5f && _speed > 0)
        {
            A_speed += 0.5f;
        }

        so_Setting.SpeedSet(A_speed);
        ui.SpeedText(so_Setting.Game_Speed);
    }
}
