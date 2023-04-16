using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_DescManager : MonoBehaviour
{
    [SerializeField] SO_Object so_object;
    [SerializeField] SO_Player so_Player;
    [SerializeField] GameObject descPanel;
    [SerializeField, Header("0 = prev / 1 = next / 2 = a / 3 = b / 4 = c / 5 = d")] GameObject[] g_Button = new GameObject[6];
    [SerializeField] Text[] option_Text = new Text[4];
    [SerializeField] Text descText;
    [SerializeField] Image StandImage;
    string s_name = "";
    string s_id;
    string s_temp_id;
    string s_count;
    string happyCount;
    string moneyCount;

    List<Dictionary<string, object>> data_Dialog;
    List<int> l_count = new List<int>();
    List<string> l_Select = new List<string>();
    int i_count = 0;
    private void Start()
    {
        data_Dialog = CSVReader.Read("text_Table");

    }
    public void startDesc(string _name, Sprite _sprite)
    {
        StandImage.sprite = _sprite;
        RectTransform rect = (RectTransform)StandImage.transform;
        rect.sizeDelta = new Vector2(_sprite.texture.width / 1.5f, _sprite.texture.height / 1.5f);

        so_object.setEnabled(true);
        descPanel.SetActive(true);
        i_count = 0;
        l_count.Add(0);
        l_Select.Add("n");

        //next버튼 빼고 다 비활성화
        for (int i = 0; i < 6; i++)
            g_Button[i].SetActive(false);
        g_Button[1].SetActive(true);

        s_name = _name;

        Buttons(1);
    }
    public void Buttons(int _num)
    {
        l_count[i_count] = l_count[i_count] + _num;

        //아이디 생성//
        s_count = l_count[i_count] < 10 ? s_count = string.Format("0{0}", l_count[i_count]) : s_count = string.Format("{0}", l_count[i_count]);

        //셀렉트 체크//
        if (l_Select.Count >= 2)
        {
            s_id = string.Format("{0}_{1}{2}", s_temp_id, l_Select[i_count], s_count);
        }
        else
        {
            s_id = string.Format("{0}_{1}_{2}", s_name, so_object.DayCount, s_count);
        }

        Debug.Log(s_id);

        if (l_count[i_count] == 1)
            g_Button[0].SetActive(false);
        else
            g_Button[0].SetActive(true);

        Desc();
    }

    private void Desc()
    {
        for (int i = 0; i < data_Dialog.Count; i++)
        {
            if(data_Dialog[i]["id"] != null)
            {
                if ((string)data_Dialog[i]["id"] == s_id && (string)data_Dialog[i]["type"] == "null")
                {
                    descText.text = (string)data_Dialog[i]["desc"];

                    happyCount = data_Dialog[i]["happy"].ToString();
                    moneyCount = data_Dialog[i]["money"].ToString();

                    if (happyCount != "0")
                    {                        
                        string[] _happy = happyCount.Split('/');
                        so_Player.setHappy(int.Parse(_happy[0]));

                    }
                    if (moneyCount != "0")
                    {
                        string[] _money = moneyCount.Split('/');
                        so_Player.setMoney(int.Parse(_money[0]));
                    }
                    return;
                }
                else if ((string)data_Dialog[i]["id"] == s_id && (string)data_Dialog[i]["type"] != "null")
                {
                    happyCount = data_Dialog[i]["happy"].ToString();
                    moneyCount = data_Dialog[i]["money"].ToString();

                    descText.text = (string)data_Dialog[i]["desc"];
                    Desc_Option(i);
                    return;
                }
            }
                   
        }
        Desc_Over();
    }

    private void Desc_Option(int _index) //옵션 갯수확인 및 버튼 생성
    {
        string option = (string)data_Dialog[_index]["type"];
        string[] s_option;
        int option_count = 1;

        s_option = option.Split('/');

        g_Button[0].SetActive(false);
        g_Button[1].SetActive(false);

        for (int i = 0; i < s_option.Length; i++)
        {
            option_count++;
            option_Text[i].text = s_option[i];
            g_Button[option_count].SetActive(true);
        }
    }

    public void Desc_Select(string _case)
    {
        for (int i = 0; i < 6; i++)
            g_Button[i].SetActive(false);
        g_Button[1].SetActive(true);

        s_temp_id = s_id; //선택 전 값 저장

        int _iCase = 0;
        switch (_case)
        {
            case "a":
                _iCase = 0;
                break;
            case "b":
                _iCase = 1;
                break;
            case "c":
                _iCase = 2;
                break;
            case "d":
                _iCase = 3;
                break;
        }
        if (happyCount != "0")
        {
            string[] _happy = happyCount.Split('/');
            so_Player.setHappy(int.Parse(_happy[_iCase]));
        }
        if (moneyCount != "0")
        {
            string[] _money = moneyCount.Split('/');
            so_Player.setMoney(int.Parse(_money[_iCase]));
        }

        l_count.Add(0);
        l_Select.Add(_case);
        i_count++;

        Buttons(1);
    }

    void Desc_Over()
    {
        so_object.setEnabled(false);
        descPanel.SetActive(false);

        s_id = "";
        s_temp_id = "";
        s_count = "";
        s_name = "";
        l_count.RemoveRange(0, i_count+1);
        l_Select.RemoveRange(0, i_count+1);        
        i_count = 0;
    }
}