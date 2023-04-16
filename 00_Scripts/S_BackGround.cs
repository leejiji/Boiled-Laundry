using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BackGround : MonoBehaviour
{
    [SerializeField, Header("===SO===")] SO_Player so_player;
    [SerializeField] SO_Setting so_Setting;
    [SerializeField] SO_Object so_Object;
    [SerializeField] S_MapScroll scroll;

    [SerializeField, Header("GameObj")] GameObject BackMap;
    [SerializeField] Animator Light;
    [SerializeField] GameObject[] BackImage;
    [SerializeField] GameObject[] SkyImage;
    [SerializeField] Sprite[] BackSprite;
    [SerializeField] Sprite[] SkySprite;



    [SerializeField, Range(0f, 10f)] public float M_speed = 0f;
    int tempDay = -1;
    int tempScroll = 0;

    void Update()
    {
        if (so_Object.IsEnabled == false && so_player.IsMove)
            BackMap.transform.Translate(-M_speed * Time.deltaTime * so_Setting.Game_Speed, 0, 0);

        if (BackMap.transform.position.x <= -41.6f)
            BackMap.transform.position = new Vector3(0, 0, 0);

        if(tempScroll != scroll.mapNum)
        {
            if(tempDay >= 9 && tempDay < 12)
            {
                if (scroll.mapNum == 6)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Light.Play("01_Sunset");
                        SkyImage[i].GetComponent<Animator>().Play("03_WinterSunset");
                        SkyImage[i].GetComponent<SpriteRenderer>().sprite = SkySprite[1];
                    }
                }
                else if (scroll.mapNum == 9)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Light.Play("02_Night");
                        SkyImage[i].GetComponent<Animator>().Play("01_Night");
                        SkyImage[i].GetComponent<SpriteRenderer>().sprite = SkySprite[2];
                    }
                }
                else if (scroll.mapNum == 11)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Light.Play("00_Morning");
                        SkyImage[i].GetComponent<Animator>().Play("04_WinterMorning");
                        SkyImage[i].GetComponent<SpriteRenderer>().sprite = SkySprite[3];
                    }
                }
            }
            else
            {
                if (scroll.mapNum == 6)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Light.Play("01_Sunset");
                        SkyImage[i].GetComponent<Animator>().Play("00_Sunset");
                        SkyImage[i].GetComponent<SpriteRenderer>().sprite = SkySprite[1];
                    }
                }
                else if(scroll.mapNum == 9)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Light.Play("02_Night");
                        SkyImage[i].GetComponent<Animator>().Play("01_Night");
                        SkyImage[i].GetComponent<SpriteRenderer>().sprite = SkySprite[2];
                    }
                }
                else if(scroll.mapNum == 11)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Light.Play("00_Morning");
                        SkyImage[i].GetComponent<Animator>().Play("02_Morning");
                        SkyImage[i].GetComponent<SpriteRenderer>().sprite = SkySprite[0];
                    }
                }
            }
            tempScroll = scroll.mapNum;
        }
        if (int.Parse(so_Object.DayCount) != tempDay)
        {        
            tempDay = int.Parse(so_Object.DayCount);

            if (tempDay < 3)
            {
                for (int i = 0; i < 5; i++)
                {
                    BackImage[i].GetComponent<SpriteRenderer>().sprite = BackSprite[0];
                }
            }
            else if (tempDay >= 3 && tempDay < 6)
            {
                for (int i = 0; i < 5; i++)
                {
                    BackImage[i].GetComponent<SpriteRenderer>().sprite = BackSprite[1];
                }
            }
            else if (tempDay >= 6 && tempDay < 9)
            {
                for (int i = 0; i < 5; i++)
                {
                    BackImage[i].GetComponent<SpriteRenderer>().sprite = BackSprite[2];
                }
            }
            else if (tempDay >= 9 && tempDay < 12)
            {
                for (int i = 0; i < 5; i++)
                {
                    BackImage[i].GetComponent<SpriteRenderer>().sprite = BackSprite[3];
                }
            }
        }
    }
}
